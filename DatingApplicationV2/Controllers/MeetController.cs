using System;
using System.Threading.Tasks;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    public class MeetController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMeetService _meetService;
        private readonly IFriendService _friendService;
        private readonly IUserRepository _userRepository;

        public MeetController(IUserService userService, IMeetService meetService, IFriendService friendService, IUserRepository userRepository)
        {
            _userService = userService;
            _meetService = meetService;
            _friendService = friendService;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            return await Task.Run<ActionResult>(() =>
            {
                return RedirectToAction(nameof(MeetsList), new { returnURL });
            });
        }

        public async Task<IActionResult> MeetsList(string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            return View(await _meetService.UserMeetsAcceptedAsync(_userService.CurrentUserId));
        }

        public async Task<IActionResult> Meet(Guid withId, string returnURL = null)
        {
            if(await _friendService.AreFriendsAsync(_userService.CurrentUserId, withId))
            {
                ViewBag.returnURL = returnURL;
                return View();
            }
            return await Task.Run<ActionResult>(() =>
            {
                return RedirectToAction(nameof(FriendshipsController.NotFriend), nameof(FriendshipsController), new { returnURL });
            });
        }

        public async Task<IActionResult> MeetConfirm(Guid withId, string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            return View(await _meetService.UserMeetsAcceptedAsync(_userService.CurrentUserId));
        }
    }
}