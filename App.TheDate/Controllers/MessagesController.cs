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
using App.Model.Error;

namespace App.TheDate.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IUserRepository _userRepository;
        private readonly IConversationsService _conversationsService;
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IConversationRepository conversationRepository, IUserService userService, IFriendService friendService, IUserRepository userRepository, IConversationsService conversationsService, IMessageRepository messageRepository)
        {
            _conversationRepository = conversationRepository;
            _userService = userService;
            _friendService = friendService;
            _userRepository = userRepository;
            _conversationsService = conversationsService;
            _messageRepository = messageRepository;
        }


        // GET: Messages
        public async Task<IActionResult> Conversation(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            ViewBag.Messages = await _messageRepository.FindByAsync(_ => _.ConversationId == id, _ => _.Sender);
            return View(await _conversationRepository.GetSingleAsync(_ => _.Id == id, _ => _.Users));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid conversationId, string content, string returnURL = null)
        {
            var conversation = await _conversationRepository.GetSingleAsync(_ => _.Id == conversationId, _ => _.Users, _ => _.Messages);
            var message = new Message() { Content = content, SenderId = _userService.CurrentUserId };
            conversation.Messages = conversation.Messages.Concat(new[] { message }).ToList();
            _conversationRepository.Update(conversation);
            await _conversationRepository.CommitAsync();
            return RedirectToAction(nameof(Conversation), new { conversation.Id, returnURL });
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
