using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Service.Abstract;
using App.Model.Entities;
using App.Repository.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using App.Model.View;
using Pagination;
using App.Model.Enumerations;
using System.Linq.Expressions;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ExploreController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IInterestRepository _interestRepository;
        private readonly IMapper _mapper;
        private readonly IExploreService _exploreService;

        public ExploreController(IUserService userService, IUserRepository userRepository, IInterestRepository interestRepository, IMapper mapper)
        {
            _userService = userService;
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Users(string sortOrder,
            string currentFilter,
            string searchString,
            int? pageSize,
            int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PageSize"] = pageSize ?? 10;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var appUsers = await _userRepository.GetAllAsync();
            if (!String.IsNullOrEmpty(searchString))
            {

                var tempUsersData = appUsers.Where(_ => _userService.IsFilledAsync(_.Id).Result).ToList();
                appUsers = tempUsersData.Any() ? tempUsersData : appUsers;

                tempUsersData = appUsers.Where(s =>
                    s.FirstName.Contains(searchString) ||
                    s.LastName.Contains(searchString) ||
                    s.Description.Contains(searchString)
                ).ToList();

                appUsers = tempUsersData.Any() ? tempUsersData : appUsers;
            }
            switch (sortOrder)
            {
                case "first_name_desc":
                    appUsers = appUsers.OrderByDescending(s => s.FirstName).ToList();
                    break;
                case "last_name_desc":
                    appUsers = appUsers.OrderByDescending(s => s.LastName).ToList();
                    break;
                case "Date":
                    appUsers = appUsers.OrderBy(s => s.BirthDate).ToList();
                    break;
                case "date_desc":
                    appUsers = appUsers.OrderByDescending(s => s.BirthDate).ToList();
                    break;
                default:
                    appUsers = appUsers.OrderBy(s => s.LastName).ToList();
                    break;
            }

            var viewModel = _mapper.Map<List<User>, List<ApplicationUserViewModel>>(appUsers.ToList());
            var result = (PaginatedList<ApplicationUserViewModel>.Create(viewModel, page ?? 1, pageSize ?? 10));
            return View(result);
        }
    }
}