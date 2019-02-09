using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using App.Model.Error;
using Microsoft.AspNetCore.Authorization;
using App.Service;

namespace App.TheDate.Controllers
{
    [Authorize(Roles="Admin,User,Moderator")]
    public class MessagesController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationsService _conversationsService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly Guid _userId;

        public MessagesController(IMessageRepository messageRepository, IConversationsService conversationsService, IUserService userService, IUserRepository userRepository) 
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _conversationsService = conversationsService;
            _userService = userService;
            _userId = _userService.CurrentUserId;
        }

        // GET: Messages
        public async Task<IActionResult> Conversation(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            var result = await _conversationsService.GetAsync(id, _ => _.Users, _ => _.Messages);
            ViewBag.ConversationUsers = await _userRepository.FindByAsync(_=>_.Conversations.Select(__=>__.ConversationId).Contains(id));
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid conversationId, string content, string returnURL = null)
        {
            var message = new Message() { Content = content, SenderId = _userId, ConversationId = conversationId };
            await _messageRepository.AddAsync(message);
            await _messageRepository.CommitAsync();
            return RedirectToAction(nameof(Conversation), new { id=conversationId, returnURL });
        }

        public async Task<IActionResult> Delete(Guid? id, string returnURL = null)
        {
            if (!id.HasValue)
                return NotFound();
            var message = await _messageRepository
                .GetSingleAsync(_ => _.Id == (id.Value));
            if (message == null)
            {
                var error = new ItemError() { Id = id.Value, Type = typeof(Message) };
                return RedirectToAction("ItemNotFound", "Error", new { error, returnURL });
            }

            ViewBag.ReturnURL = returnURL;
            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var msg = await  _messageRepository.GetSingleAsync(id);
            _messageRepository.DeleteWhere(_ => _.Id == id);
            await _messageRepository.CommitAsync();
            return RedirectToAction(nameof(Conversation), new { id = msg.ConversationId });
        }
    }
}
