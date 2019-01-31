using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using App.Service.Abstract;
using App.Model.Entities;
using App.Model.Enumerations;
using App.Repository.Abstract;
using System.Linq;

namespace TheDate.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class FriendshipsController : Controller
    {

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IFriendService _friendshipService;
        private readonly IMeetService _meetService;

        public FriendshipsController(IUserService userService, IUserRepository userRepository, IFriendService friendshipService, IMeetService meetService)
        {
            _userService = userService;
            _userRepository = userRepository;
            _friendshipService = friendshipService;
            _meetService = meetService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(UserFriends), new { id = _userService.CurrentUserId});
        }

        public async Task<IActionResult> UserFriends(Guid id)
        {
            var usersMarkedAsMet = await _meetService.UsersMarkedAsMetAsync(id);
            var usersMet = await _meetService.UserMeetsAcceptedAsync(id);
            ViewBag.MarkedAsMet = usersMarkedAsMet.Select(_ => _.Id);
            ViewBag.UsersMet = usersMet.Select(_=>_.Id);
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
            var friend = await _userRepository.GetSingleAsync(id);
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

        public async Task <IActionResult> NotFriend(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(_=>_.Id==id));
        }

        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddConfirmed(Guid id, string returnURL = null)
        {
            _friendshipService.AddFriend(_userService.CurrentUserId, id);
            return Redirect(returnURL);
        }
        public IActionResult AlreadyInvited(User user, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(user);
        }
        public async Task<IActionResult> AlreadyFriends(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(id) );
        }
        public async Task<IActionResult> NotAcceptJet(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(id));
        }

        public async Task<IActionResult> Delete(Guid id, string returnURL = null)
        {
            var friendship = await _friendshipService.GetAsync(id, _userService.CurrentUserId);
            if (friendship == null)
                return RedirectToAction("ItemNotFound", "ErrorController", new { exception = "TO DO" } );
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string returnURL = null)
        {
            await _friendshipService.DeleteFriendAsync(id, _userService.CurrentUserId);
            ViewBag.ReturnURL = returnURL;
            return RedirectToAction(nameof(DeleteSuccess), new { id, returnURL } );
        }
        public async Task<IActionResult> DeleteSuccess(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _userRepository.GetSingleAsync(id));
        }
    }
}
