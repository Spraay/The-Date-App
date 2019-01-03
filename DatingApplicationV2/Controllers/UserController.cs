using System;
using System.Collections.Generic;
using System.Linq;
using App.Abstract;
using DatingApplicationV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Validators;
using System.Threading.Tasks;
using App.Model;
using App.Service.Abstract;
using App.Model.Abstract;
using App.Repository;

namespace DatingApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IImageService _imageService;
        private readonly IImageLikeService _imageLikeService;
        private readonly IInterestRepository _interestRepository;

        public UserController(IMapper mapper, IUserService userService, IFriendService friendService, IImageService imageService, IImageLikeService imageLikeService, IInterestRepository interestRepository)
        {
            _mapper = mapper;
            _userService = userService;
            _friendService = friendService;
            _imageService = imageService;
            _imageLikeService = imageLikeService;
            _interestRepository = interestRepository;
        }

        // GET: Default
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            if ( await _userService.IsFilledAsync(_userService.CurrentUserId) )
                return RedirectToAction(nameof(Profile), new { id = _userService.CurrentUserId });
            return RedirectToAction(nameof(Edit));
        }


        public async Task<ActionResult> Profile(Guid id)
        {
            var user = await _userService.GetSingleAsync(
                _ => _.Id == id,
                _ => _.Interests,
                _ => _.Gallery,
                _ => _.ImagesComments,
                _ => _.ImagesLikes,
                _ => _.InvitationsReceived,
                _ => _.InvitationsSent,
                _ => _.Roles);

            ViewBag.Friends                 = await _friendService.GetUserFriendsAsync(id);
            ViewBag.PhotosLikes             = await _imageLikeService.CountImageLikesAsync(id);
            ViewBag.CurrentUserId           = _userService.CurrentUserId;
            ViewBag.IsModelUserFilled       = await _userService.IsFilledAsync(id);
           
            return View(user);
        }

        // GET: Default/Edit
        [Authorize(Roles = "User")]
        public ActionResult Edit(string returnURL = null)
        {
            var user = _userService.GetSingle(_userService.CurrentUserId);
            PopulateAssignedInterestData(user);
            var viewModel = _mapper.Map<User, ApplicationUserViewModel>(user);
            if (_userService.IsFilled(user.Id))
                ViewBag.isFilled = true;
            else
                ViewBag.isFilled = false;
            ViewBag.ReturnURL = returnURL;
            return View(viewModel);
        }

        private void PopulateAssignedInterestData(User user)
        {
            var allInterests = _interestRepository.GetAll();
            var applicationUserInterests = new HashSet<Guid>(_interestRepository.GetUserInterests(user.Id).Select(_=>_.Id));
            var viewModel = new List<AssignedInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new AssignedInterestData
                {
                    InterestID = interest.Id,
                    InterestName = interest.Name,
                    Assigned = applicationUserInterests.Contains(interest.Id)
                });
            }
            ViewBag.Interests = viewModel;
        }

        // POST: Default/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Edit(User user, Guid[] selectedInterests, string selectedGender, string selectedEyes, string returnURL = null)
        {
            try
            {
                _userService.UpdateGender(selectedGender);
                _userService.UpdateEyes(selectedEyes);
                _interestRepository.UpdateUserInterest(_userService.CurrentUserId, selectedInterests);
                if (returnURL == null)
                    return RedirectToAction(nameof(Index));
                return Redirect(returnURL);
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAssignedInterestData(user);
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }

        public ActionResult RegisterSuccess(string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }
    }
}