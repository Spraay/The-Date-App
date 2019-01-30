using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace App.TheDate.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ConversationsController : Controller
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IUserRepository _userRepository;
        private readonly IConversationsService _conversationsService;

        public ConversationsController(IConversationRepository conversationRepository, IUserService userService, IFriendService friendService, IUserRepository userRepository, IConversationsService conversationsService)
        {
            _conversationRepository = conversationRepository;
            _userService = userService;
            _friendService = friendService;
            _userRepository = userRepository;
            _conversationsService = conversationsService;
        }

        // GET: Conversations
        public async Task<IActionResult> Index(string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(await _conversationRepository.GetUserConversationsAsync(_userService.CurrentUserId));
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
                var users = new List<ConversationUser>();
                foreach(var uId in selectedUsers)
                {
                    users.Add( new ConversationUser() { UserId = uId, ConversationId = conversation.Id } );
                }
                conversation.Users = users;
                await _conversationRepository.AddAsync(conversation);
                await _conversationRepository.CommitAsync();
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

            var conversation = await _conversationRepository.GetSingleAsync(_ => _.Id == id, _ => _.Users, _ => _.Messages);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Conversation conversation, string[] selectedUsers, string returnURL = null)
        {
            if (id != conversation.Id)
                return NotFound();

            if (ModelState.IsValid)
            {

                await _conversationsService
                    .UpdateAsync(conversation.Name, await _friendService.GetUserFriendsAsync(_userService.CurrentUserId), selectedUsers, id);
                

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

            var conversation = await _conversationRepository.GetSingleAsync(_ => _.Id == id, _ => _.Users, _ => _.Messages);
            if (conversation == null || !conversation.Users.Select(_ => _.UserId).Contains(_userService.CurrentUserId))
                return NotFound();

            return View(conversation);
        }

        // POST: Conversations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string returnURL = null)
        {
            var conversation = await _conversationRepository.GetSingleAsync(_ => _.Id == id, _ => _.Users, _ => _.Messages);
            if (conversation == null || !conversation.Users.Select(_ => _.UserId).Contains(_userService.CurrentUserId))
                return NotFound();

            _conversationRepository.Delete(conversation);
            await _conversationRepository.CommitAsync();
            return RedirectToAction(nameof(Index), new { returnURL });
        }

        private async Task<bool> ConversationExists(Guid id)
        {
            var conversation = await _conversationRepository.GetSingleAsync(e => e.Id == id);
            if (conversation == null)
                return false;
            return true;
        }
    }
}
