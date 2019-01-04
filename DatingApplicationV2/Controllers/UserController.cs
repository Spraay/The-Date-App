using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Repository.Abstract;
using App.Model.Entities;
using App.Model.View;
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<User> _userManager;

        public UserController(IMapper mapper, IUserService userService, IFriendService friendService, IImageService imageService, IImageLikeService imageLikeService, IInterestRepository interestRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userService = userService;
            _friendService = friendService;
            _imageService = imageService;
            _imageLikeService = imageLikeService;
            _interestRepository = interestRepository;
            _userManager = userManager;
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
            var user = await _userService.GetSingleWithAllPropertiesAsync(id);
                

            ViewBag.Friends                 = await _friendService.GetUserFriendsAsync(id);
            ViewBag.PhotosLikes             = await _imageLikeService.CountImageLikesAsync(id);
            ViewBag.CurrentUserId           = _userService.CurrentUserId;
            ViewBag.IsModelUserFilled       = await _userService.IsFilledAsync(id);
            ViewBag.Roles                   = await _userManager.GetRolesAsync(_userService.Get(id));
            return View(user);
        }

        // GET: Default/Edit
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(string returnURL = null)
        {
            var user = await _userService.GetAsync(_userService.CurrentUserId);
            await _userService.PopulateAssignedInterestData(user);
            var viewModel = _mapper.Map<User, ApplicationUserViewModel>(user);
            if (_userService.IsFilled(user.Id))
                ViewBag.isFilled = true;
            else
                ViewBag.isFilled = false;
            ViewBag.ReturnURL = returnURL;
            return View(viewModel);
        }

        

        // POST: Default/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public ActionResult Edit(User user, string[] selectedInterests, string selectedGender, string selectedEyes, /*TODO: string selectedHair,*/ string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            try
            {
                _userService.Update(user, selectedInterests, selectedEyes, selectedGender/*, selectedHair*/);
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                var viewModel = _mapper.Map<User, ApplicationUserViewModel>(user);
                return RedirectToAction(nameof(Edit));
            }
            _userService.PopulateAssignedInterestData(user);
            if( returnURL == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return Redirect(returnURL);
        }


        public ActionResult RegisterSuccess(string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }
    }
}