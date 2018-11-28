using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;

namespace DatingApplicationV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class ConversationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFriendService _friendshipService;
        private readonly IConversationService _conversationService;

        public ConversationController(IUserService userService, IFriendService friendshipService, IConversationService conversationService)
        {
            _userService = userService;
            _friendshipService = friendshipService;
            _conversationService = conversationService;
        }


        [HttpGet]
        [Route(nameof(GetUserConversations))]
        public ActionResult<List<Conversation>> GetUserConversations()
        {
            string json = JsonConvert.SerializeObject(_conversationService.GetUserConversations(_userService.CurrentUserId, true, true), Formatting.Indented);
            return new JsonResult(json);
        }
    
    }

}