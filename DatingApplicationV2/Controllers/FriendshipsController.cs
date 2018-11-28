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


        // GET: Friendships
        public IActionResult Index()
        {
            return RedirectToAction(nameof(UserFriends), new { userID = _userService.CurrentUserId});
        }

        public IActionResult UserFriends(Guid userID)
        {
            return View(_friendshipService.GetFriendships(userID));
        }

        public IActionResult InvitationsSent()
        {
            return View(_friendshipService.GetInvitationsSent(_userService.CurrentUserId));
        }

        public IActionResult InvitationsReceived()
        {
            return View(_friendshipService.GetInvitationsReceived(_userService.CurrentUserId));
        }

        public IActionResult Invite(Guid friendID)
        {
            var friendship = _friendshipService.GetUsersFriendsip(_userService.CurrentUserId, friendID);
            var friend = _userService.Get(friendID);
            if ( friendship==null)
            {
                return View(friend);
            }
            if( friendship.FriendId == friendID && friendship.Status != Status.Accepted)
            {
                return RedirectToAction(nameof(NotAcceptJet), friend);  
            }
            if (friendship.SenderId == friendID && friendship.Status != Status.Accepted)
            {
                return View(friend);
            }
            if ( _friendshipService.AreFriends(_userService.CurrentUserId, friendID))
            {
                return RedirectToAction(nameof(AlreadyFriends), friend);
            }
            return AlreadyInvited(friend);

        }

        [HttpPost, ActionName("Invite")]
        [ValidateAntiForgeryToken]
        public IActionResult InviteConfirmed(Guid Id)
        {
            _friendshipService.InviteFriend(Id);
            return RedirectToAction(nameof(InvitationsSent));
        }
        public IActionResult AlreadyInvited(ApplicationUser user)
        {
            return View(user);
        }
        public IActionResult AlreadyFriends(ApplicationUser user)
        {
            return View(user);
        }
        public IActionResult NotAcceptJet(ApplicationUser user)
        {
            return View(user);
        }

        public IActionResult Delete(Guid user1ID, Guid user2ID)
        {
            var friendship = _friendshipService.GetUsersFriendsip(user1ID, user2ID);
            if (friendship == null)
                return NotFound();
            ViewBag.Friend = friendship.Friend;
            return View(friendship);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid SenderId, Guid FriendId)
        {
            _friendshipService.Remove(SenderId, FriendId);
            return RedirectToAction(nameof(Index));
        }
    }
}
