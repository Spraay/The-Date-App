using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Model.Entities;
using App.Model.API;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesApiController : ControllerBase
    {
        private readonly IConversationService _conversationsService;
        private readonly IUserService _userService;

        public MessagesApiController(IConversationService conversationsService, IUserService userService)
        {
            _conversationsService = conversationsService;
            _userService = userService;
        }

        [HttpGet]
        [Route("conversation/{id}")]
        public async Task<JObject> GetConversationDetails(Guid id)
        {
            if(await _conversationsService.IsExistsAsync(id))
            { 
                var queryResult =  await _conversationsService.GetAsync(id, _=>_.Users, _=>_.Messages);
                var users = queryResult.Users.Select(_ => _.User).Select(_ => new { _.Id, _.FirstName, _.LastName, _.ProfileImageSrc });
                JObject o = JObject.FromObject(new
                {
                    queryResult.Id,
                    queryResult.Name,
                });
                return o;
            }
            return ObjectNotExists(id);
        }

        //[HttpGet]
        //[Route("conversation/{id}/users")]
        //public async Task<JObject> GetConversationUsers(Guid id)
        //{
        //    if (await _conversationsService.IsExistsAsync(id))
        //    {
        //        var queryResult = (List<Conversation>)await _conversationsService.GetAsync(id, _ => _.Users);
        //        var users = await _userService.FindByAsync(_ => queryResult..Select(__ => __.User).)
        //        JObject o = JObject.FromObject(new
        //        {
        //            id,
        //            queryResult.Name,
        //        });
        //        return o;
        //    }
        //    return ObjectNotExists(id);
        //}



        private JObject ObjectNotExists(Guid id)
        {
            return new JObject($"Object with id {id} Not Exists in database");
        }
    }
}
