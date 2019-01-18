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

        public ExploreController(IUserService userService, IUserRepository userRepository, IInterestRepository interestRepository, IMapper mapper, IExploreService exploreService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _mapper = mapper;
            _exploreService = exploreService;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Users(string sortItem, string sortOrder,
            string currentFilter,
            string searchString,
            string filtrMale,
            string filtrFemale,
            int? pageSize,
            int? page)
        {
            ViewData["SortItem"] = String.IsNullOrEmpty(sortItem) ? "last_name" : sortItem;
            ViewData["SortOrder"] = String.IsNullOrEmpty(sortOrder) ? "asce" : sortOrder;
            ViewData["PageSize"] = pageSize ?? 10;
            ViewData["FiltrMale"] = String.IsNullOrEmpty(filtrMale) ? "false" : filtrMale;
            ViewData["FiltrFemale"] = String.IsNullOrEmpty(filtrFemale) ? "false" : filtrFemale;

            var temp = string.Empty;
            if (searchString != null)
            {
                page = 1;
                temp = searchString.Replace(" ", string.Empty);
            }
            else
            {
                searchString = currentFilter;
            }
                
            ViewData["SearchString"] = searchString;
            
            var appUsers = (!String.IsNullOrEmpty(temp))
                ? await _userRepository.FindByAsync(_=> temp.Contains(_.FirstName) || temp.Contains(_.LastName) || temp.Contains(_.Description))
                : await _userRepository.GetAllAsync();

            if(filtrMale == "true")
                appUsers = appUsers.Where(_ => _.Gender != Gender.Male);

            if (filtrFemale == "true")
                appUsers = appUsers.Where(_ => _.Gender != Gender.Female);

            switch (sortItem+"_"+sortOrder)
            {
                case "first_name_asce":
                    appUsers = appUsers.OrderBy(s => s.FirstName).ToList();
                    ViewBag.SortItemName = "First Name";
                    ViewBag.SortOrderName = "Ascending";
                    break;
                case "first_name_desc":
                    appUsers = appUsers.OrderByDescending(s => s.FirstName).ToList();
                    ViewBag.SortItemName = "First Name";
                    ViewBag.SortOrderName = "Descending";
                    break;
                case "last_name_asce":
                    appUsers = appUsers.OrderBy(s => s.LastName).ToList();
                    ViewBag.SortItemName = "Last Name";
                    ViewBag.SortOrderName = "Ascending";
                    break;
                case "last_name_desc":
                    appUsers = appUsers.OrderByDescending(s => s.LastName).ToList();
                    ViewBag.SortItemName = "Last Name";
                    ViewBag.SortOrderName = "Descending";
                    break;
                case "date_asce":
                    appUsers = appUsers.OrderBy(s => s.BirthDate).ToList();
                    ViewBag.SortItemName = "Born Date";
                    ViewBag.SortOrderName = "Ascending";
                    break;
                case "date_desc":
                    appUsers = appUsers.OrderByDescending(s => s.BirthDate).ToList();
                    ViewBag.SortItemName = "Born Date";
                    ViewBag.SortOrderName = "Descending";
                    break;
            }
            var viewModel = _mapper.Map<List<User>, List<ApplicationUserViewModel>>(appUsers.ToList());
            var result = (PaginatedList<ApplicationUserViewModel>.Create(viewModel, page ?? 1, pageSize ?? 10));
            return View(result);
        }
    }
}