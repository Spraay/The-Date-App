using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAO.Data;
using Enties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Services;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class FriendshipsController : Controller
    {

        private readonly IUserService _userService;
        private readonly IFriendService _friendshipService;

        public FriendshipsController(IUserService userService, IFriendService friendshipService)
        {
            _userService = userService;
            _friendshipService = friendshipService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(UserFriends), new { id = _userService.CurrentUserId});
        }

        public async Task<IActionResult> UserFriends(Guid id)
        {
            return View( await _friendshipService.GetUserFriendsAsync(id) );
        }

        public async Task<IActionResult> InvitationsSent()
        {
            return View(await _friendshipService.GetInvitationsSentAsync(_userService.CurrentUserId));
        }

        public async Task<IActionResult> InvitationsReceived()
        {
            return View(await _friendshipService.GetInvitationsReceivedAsync(_userService.CurrentUserId));
        }

        public async Task<IActionResult> Add(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetAsync(_userService.CurrentUserId, id);
            var friend = _userService.Get(id);
            ViewBag.ReturnURL = returnURL;
            if ( friendship==null)
            {
                return View(friend);
            }
            if( friendship.FriendId == id && friendship.Status != Status.Accepted)
            {
                return RedirectToAction(nameof(NotAcceptJet), new { id, returnURL });  
            }
            if (friendship.SenderId == id && friendship.Status != Status.Accepted)
            {
                return View(friend);
            }
            if ( _friendshipService.AreFriends(_userService.CurrentUserId, id))
            {
                return RedirectToAction(nameof(AlreadyFriends), new { id, returnURL });
            }
            return AlreadyInvited(friend);
        }

        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddConfirmed(Guid id, string returnURL = null)
        {
            _friendshipService.AddFriend(_userService.CurrentUserId, id);
            return Redirect(returnURL);
        }
        public IActionResult AlreadyInvited(ApplicationUser user, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }
        public async Task<IActionResult> AlreadyFriends(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userService.GetAsync(id) );
        }
        public async Task<IActionResult> NotAcceptJet(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userService.GetAsync(id));
        }

        public async Task<IActionResult> Delete(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetAsync(id, _userService.CurrentUserId);
            if (friendship == null)
                return RedirectToAction("ItemNotFound", "ErrorController", new { exception = "asdasdasd" } );
            ViewBag.ReturnURL = returnURL;
            return View(friendship);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string returnURL = null)
        {
            await _friendshipService.DeleteFriendAsync(id, _userService.CurrentUserId);
            ViewBag.ReturnURL = returnURL;
            return View();
        }
    }
}
