using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Model.Entities;
using App.Model.View;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesApiController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IConversationService _conversationsService;
        private readonly IUserService _userService;

        public MessagesApiController(IMessageService messageService, IConversationService conversationsService, IUserService userService)
        {
            _messageService = messageService;
            _conversationsService = conversationsService;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        [Route("conversations")]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllMessages()
        {
            var result = await _messageService.GetAllAsync();
            return result.ToList();
        }

        [HttpGet]
        [Route("conversation/{id}")]
        public async Task<ActionResult<Conversation>> GetConversation(Guid id)
        {
            var qR = await _conversationsService.GetAsync(id, _ => _.Users, _ => _.Messages);
            var cUsers = await _userService.FindByAsync(_=> qR.Users.Select(__=>__.UserId).Contains(_.Id));
            return new JsonResult(new ConversationViewModel()
            {
                Id = id,
                Name = qR.Name,
                Messages = qR.Messages.ToList(),
                Users = cUsers.ToList()
            });
        }

        


        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
