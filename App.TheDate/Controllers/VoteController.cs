using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    public class VoteController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly IMeetService _meetService;
        private readonly IFriendService _friendService;

        public VoteController(IUserService userService, IUserRepository userRepository, IVoteRepository voteRepository, IMeetService meetService, IFriendService friendService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _voteRepository = voteRepository;
            _meetService = meetService;
            _friendService = friendService;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Votes));
        }

        public async Task<IActionResult> Votes(Guid? id, string returnURL = null)
        {
            ViewBag.returnURL = returnURL;
            if (!id.HasValue)
                return View(await _voteRepository.FindByAsync(_=>_.Meet.WithId == _userService.CurrentUserId, _ => _.Meet));
            return View(await _voteRepository.FindByAsync(_ => _.Meet.WithId == id.Value, _ => _.Meet));
        }

        public async Task<IActionResult> Vote(Guid id, string returnURL = null)
        {
            if ((_userService.CurrentUserId == id))
            {
                var controller = nameof(MeetController).Substring(0, nameof(MeetController).Length - 10);
                return RedirectToAction(nameof(MeetController.NotMeet), controller, new { id, returnURL });
            }
            if (!await _friendService.AreFriendsAsync(_userService.CurrentUserId, id))
            {
                var controller = nameof(FriendshipsController).Substring(0, nameof(FriendshipsController).Length - 10);
                return RedirectToAction(nameof(FriendshipsController.NotFriend), controller, new { id, returnURL });
            }
            if (!await _meetService.IsMeetWithAsync(_userService.CurrentUserId, id) )
            {
                var controller = nameof(MeetController).Substring(0, nameof(MeetController).Length - 10);
                return RedirectToAction(nameof(MeetController.NotMeet), controller, new { id, returnURL });
            }
            ViewBag.returnURL = returnURL;
            return View();
        }
    }
}