using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DatingApplicationV2.Controllers
{
    public class MessageFormController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFriendService _friendshipService;
        private readonly IConversationService _conversationService;

        public MessageFormController(IUserService userService, IFriendService friendshipService, IConversationService conversationService)
        {
            _userService = userService;
            _friendshipService = friendshipService;
            _conversationService = conversationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConversationList()
        {
            return View(_conversationService.GetUserConversations(_userService.CurrentUserId, true, true));
        }

        public IActionResult Create()
        {
            // lista konwersacji
            var userConversations = _conversationService.GetUserConversations(_userService.CurrentUserId, false, true);
            ViewBag.UserConversations = userConversations;  
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID, Content, ConversationID")] Message message)
        {
            message.Sender = _userService.Get(_userService.CurrentUserId);
            message.SenderId = _userService.CurrentUserId;
            //message.ConversationID = _
            if (ModelState.IsValid)
            {
                _conversationService.SendMessage(message);
               // return RedirectToAction(nameof(Index));
            }
            var userConversations = _conversationService.GetUserConversations(_userService.CurrentUserId, false, true);
            ViewBag.UserConversations = userConversations;
            return View(message);
        }
    }
}