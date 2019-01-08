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
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IImageLikeService _imageLikeService;
        private readonly IUserInterestsService _userInterestService;
        private readonly IMeetService _meetService;
        private readonly IVoteRepository _voteRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserController(IMapper mapper, IUserService userService, IFriendService friendService, IImageLikeService imageLikeService, IUserInterestsService userInterestService, IMeetService meetService, IVoteRepository voteRepository, IUserRepository userRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userService = userService;
            _friendService = friendService;
            _imageLikeService = imageLikeService;
            _userInterestService = userInterestService;
            _meetService = meetService;
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }



        // GET: Default

        public async Task<IActionResult> Index()
        {
            if ( await _userService.IsFilledAsync(_userService.CurrentUserId) )
                return RedirectToAction(nameof(Profile), new { id = _userService.CurrentUserId });
            return RedirectToAction(nameof(Edit));
        }


        public async Task<ActionResult> Profile(Guid id)
        {
            var user = await _userRepository.GetSingleAsync(_=>_.Id == id,
                _=>_.Interests,
                _=>_.Gallery);
            ViewBag.Interests               = await _userInterestService.GetUserInterestsAsync(id);
            ViewBag.Friends                 = await _friendService.GetUserFriendsAsync(id);
            ViewBag.PhotosLikes             = await _imageLikeService.CountImageLikesAsync(id);
            ViewBag.CurrentUserId           = _userService.CurrentUserId;
            ViewBag.IsModelUserFilled       = await _userService.IsFilledAsync(id);
            ViewBag.Roles                   = await _userManager.GetRolesAsync(await _userRepository.GetSingleAsync(id));
            ViewBag.Mets                    = await _meetService.UserMeetsAcceptedCountAsync(id);
            ViewBag.Votes                   = await _voteRepository.FindByAsync(_=>_.Meet.WithId == id);
            return View(user);
        }

        // GET: Default/Edit
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(string returnURL = null)
        {
            var user = await _userRepository.GetSingleAsync(_=>_.Id==_userService.CurrentUserId, _=>_.Interests);
            ViewBag.Interests = await _userInterestService.PopulateAssignedInterestDataAsync(user.Id);
            if (await _userService.IsFilledAsync(user.Id))
                ViewBag.isFilled = true;
            else
                ViewBag.isFilled = false;
            ViewBag.ReturnURL = returnURL;
            return View(_mapper.Map<User, ApplicationUserViewModel>(user));
        }

        // POST: Default/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Edit(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes, /*TODO: string selectedHair,*/ string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            
            await _userService.UpdateAsync(user, selectedInterests, selectedGender, selectedEyes);
            if( returnURL == null)
                return RedirectToAction(nameof(Index));
            return Redirect(returnURL);
        }


        public ActionResult RegisterSuccess(string returnURL = null)
        {
            ViewBag.ReturnUrl = returnURL;
            return View();
        }
    }
}