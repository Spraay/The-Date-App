using System;
using System.Threading.Tasks;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
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

        public IActionResult Index(string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            return RedirectToAction(nameof(MeetsList), new { returnURL });
        }

        public async Task<IActionResult> MeetsList(Guid? id, string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            return View(await _meetService.UserMeetsAcceptedAsync(id ?? _userService.CurrentUserId));
        }

        public async Task<IActionResult> Meet(Guid id, string returnURL = null)
        {
            if (await _friendService.AreFriendsAsync(_userService.CurrentUserId, id))
            {
                ViewBag.returnURL = returnURL;
                return View(await _userRepository.GetSingleAsync(id));
            }
            var controller = nameof(FriendshipsController).Substring(0, nameof(FriendshipsController).Length - 10);
            return RedirectToAction(nameof(FriendshipsController.NotFriend), controller, new { id, returnURL });
        }

        public async Task<IActionResult> MeetConfirm(Guid id, string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            await _meetService.SetMeetWithAsync(_userService.CurrentUserId, id);
            return View(await _userRepository.GetSingleAsync(id));
        }

        public async Task<IActionResult> NotMeet(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(_ => _.Id == id));
        }
    }
}