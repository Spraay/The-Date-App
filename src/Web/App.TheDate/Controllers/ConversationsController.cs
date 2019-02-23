using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models.Entities;
using Core.Repositories.Abstract;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
namespace Core.TheDate.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ConversationsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IUserRepository _userRepository;
        private readonly IConversationService _conversationsService;

        public ConversationsController( IUserService userService, IFriendService friendService, IUserRepository userRepository, IConversationService conversationsService)
        {
            _userService = userService;
            _friendService = friendService;
            _userRepository = userRepository;
            _conversationsService = conversationsService;
        }

        // GET: Conversations
        public async Task<IActionResult> Index(string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _conversationsService.GetUserConversationsAsync(_userService.CurrentUserId));
        }

        // GET: Conversations/Create
        public async Task<IActionResult> Create(string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            ViewBag.UserFriends = await _friendService.GetUserFriendsAsync(_userService.CurrentUserId);
            ViewBag.CurrentUser = await _userRepository.GetSingleAsync(_userService.CurrentUserId);
            return View();
        }

        // POST: Conversations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Conversation conversation, Guid[] selectedUsers, string returnURL = null)
        {
            if (ModelState.IsValid)
            {
                conversation.Id = Guid.NewGuid();
                await _conversationsService.AddAsync(conversation);
                await _conversationsService.UpdateUsersAsync(conversation.Id, selectedUsers);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ReturnURL = returnURL;
            return View(conversation);
        }

        // GET: Conversations/Edit/5
        public async Task<IActionResult> Edit(Guid? id, string returnURL = null)
        {
            if (id == null)
                return NotFound();

            var conversation = await _conversationsService.GetAsync(id.Value, _=>_.Messages, _=>_.Users);
            if (conversation == null || !conversation.Users.Select(_ => _.UserId).Contains(_userService.CurrentUserId))
                return NotFound();

            ViewBag.ReturnURL = returnURL;
            ViewBag.UserFriends = await _friendService.GetUserFriendsAsync(_userService.CurrentUserId);
            ViewBag.CurrentUser = await _userRepository.GetSingleAsync(_userService.CurrentUserId);
            return View(conversation);
        }

        // POST: Conversations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Conversation conversation, Guid[] selectedUsers, string returnURL = null)
        {
            if (id != conversation.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _conversationsService.UpdateNameAsync(id, conversation.Name);
                await _conversationsService.UpdateUsersAsync(id, selectedUsers);
                return RedirectToAction(nameof(Index), new { returnURL });
            }
            ViewBag.ReturnURL = returnURL;
            return View(conversation);
        }

        // GET: Conversations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var conversation = await _conversationsService.GetAsync(id.Value, _ => _.Users, _ => _.Messages);
            if (conversation == null || !conversation.Users.Select(_ => _.UserId).Contains(_userService.CurrentUserId))
                return NotFound();

            return View(conversation);
        }

        // POST: Conversations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string returnURL = null)
        {
            var conversation = await _conversationsService.GetAsync(id, _ => _.Users, _ => _.Messages);
            if (conversation == null || !conversation.Users.Select(_ => _.UserId).Contains(_userService.CurrentUserId))
                return NotFound();

            await _conversationsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { returnURL });
        }
    }
}
