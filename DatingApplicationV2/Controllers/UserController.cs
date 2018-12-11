using System;
using System.Collections.Generic;
using System.Linq;
using Enties;
using Services;
using DatingApplicationV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using AutoMapper;
using Validators;
using System.Threading.Tasks;

namespace DatingApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInterestService _interestService;
        private readonly IMapper _mapper;
        private readonly IFriendService _friendService;
        private readonly IImageService _imageService;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, IInterestService interestService, IMapper mapper, IFriendService friendService, IImageService imageService)
        {
            _userService = userService;
            _userManager = userManager;
            _interestService = interestService;
            _mapper = mapper;
            _friendService = friendService;
            _imageService = imageService;
        }





        // GET: Default
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            if (_userService.IsFilled(_userService.CurrentUserId))
                return RedirectToAction(nameof(Profile), new { id = _userService.CurrentUserId });
            return RedirectToAction(nameof(Edit));
        }


        public async Task<ActionResult> Profile(Guid id)
        {
            var user = await _userService.GetAsync(id);
            ViewBag.Roles = await _userManager.GetRolesAsync(user);
            ViewBag.FriendsCount = _friendService.Count;
            ViewBag.Friends = _friendService.GetFriendships(id);
            ViewBag.Photos = _imageService.GetUserImages(id);
            ViewBag.Interests = _interestService.GetList();
            return View(_userService.Get(id));
        }

        // GET: Default/Details/5
        [Authorize(Roles = "User")]
        public ActionResult Details(Guid id)
        {
            var user = _userService.Get(id);
            PopulateAssignedInterestData(user);
            user = _userService.Get(user.Id);
            var viewModel = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            try
            {
                _userService.IsFilled(user.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(viewModel);
        }

        // GET: Default/Edit
        [Authorize(Roles = "User")]
        public ActionResult Edit()
        {
            var user = _userService.Get(Guid.Parse(_userManager.GetUserId(User)));
            PopulateAssignedInterestData(user);
            var viewModel = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            if (_userService.IsFilled(user.Id))
                ViewBag.isFilled = true;
            else
                ViewBag.isFilled = false;
            return View(viewModel);
        }

        private void PopulateAssignedInterestData(ApplicationUser user)
        {
            var allInterests = _interestService.GetList();
            var applicationUserInterests = new HashSet<Guid>(_userService.GetInterests(user.Id).Select(_=>_.ID));
            var viewModel = new List<AssignedInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new AssignedInterestData
                {
                    InterestID = interest.ID,
                    InterestName = interest.Name,
                    Assigned = applicationUserInterests.Contains(interest.ID)
                });
            }
            ViewBag.Interests = viewModel;
        }

        // POST: Default/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Edit(ApplicationUser user, string[] selectedInterests, string selectedGender, string selectedEyes)
        {
            try
            {
                _userService.Update(user, selectedInterests, selectedGender, selectedEyes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAssignedInterestData(user);
            return View(user);
        }

        // GET: Default/Delete
        [Authorize(Roles = "User")]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Delete(IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RegisterSuccess(string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }

    }
}