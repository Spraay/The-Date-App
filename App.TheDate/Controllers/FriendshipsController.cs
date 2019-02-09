using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using App.Service.Abstract;
using App.Model.Entities;
using App.Model.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace App.TheDate.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class FriendshipsController : Controller
    {
        private readonly IFriendService _friendshipService;
        private readonly IUserService _userService;
        private readonly Guid _userId;

        public FriendshipsController(IFriendService friendshipService, IUserService userService)
        {
            _friendshipService = friendshipService;
            _userService = userService;
            _userId = _userService.CurrentUserId;
        }

        public IActionResult Index(string returnURL = null)
        {
            return RedirectToAction(nameof(UserFriends), new { id = _userId, returnURL });
        }

        public async Task<IActionResult> UserFriends(Guid? id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View( await _friendshipService.GetUserFriendsAsync(id ?? _userId) );
        }

        public async Task<IActionResult> InvitationsSent()
        {
            return View(await _friendshipService.GetUserSentInvitationsAsync(_userId));
        }

        public async Task<IActionResult> InvitationsReceived()
        {
            return View(await _friendshipService.GetUserReceievedInvitationsAsync(_userId));
        }

        public async Task<IActionResult> Add(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetFriendshipBetween(_userId, id);
            var friend = await _userService.GetAsync(id);
            ViewBag.ReturnURL = returnURL;
            if (friendship == null)
                return View(friend);
            
            if (friendship.FriendId == id && friendship.Status != Status.Accepted)
                return NotAcceptJet(friend, returnURL);

            if (friendship.SenderId == id && friendship.Status != Status.Accepted)
                return View(friend);
            
            if (friendship.Status==Status.Accepted)
                return AlreadyFriends(friend, returnURL);
            
            return AlreadyInvited(friend);
        }

        public async Task <IActionResult> NotFriend(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userService.GetAsync(id));
        }

        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddConfirmed(Guid id, string returnURL = null)
        {
            _friendshipService.AddAsync(new Friendship() { SenderId = _userId, FriendId = id });
            return Redirect(returnURL);
        }
        public IActionResult AlreadyInvited(User user, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }
        public IActionResult AlreadyFriends(User user, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }
        public IActionResult NotAcceptJet(User user, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }

        public async Task<IActionResult> Delete(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetFriendshipBetween(_userId, id);
            if (friendship == null)
                return RedirectToAction("ItemNotFound", "ErrorController", new { exception = "TO DO" } );
            ViewBag.ReturnURL = returnURL;
            return View(await _userService.GetAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetFriendshipBetween(_userId, id);
            await _friendshipService.DeleteAsync(friendship.Id);
            ViewBag.ReturnURL = returnURL;
            return RedirectToAction(nameof(DeleteSuccess), new { id, returnURL } );
        }
        public async Task<IActionResult> DeleteSuccess(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userService.GetAsync(id));
        }
    }
}
