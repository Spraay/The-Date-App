using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class MessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;

        public MessageService(ApplicationDbContext context, IUserService userService, IFriendService friendService)
        {
            _context = context;
            _userService = userService;
            _friendService = friendService;
        }

        //public List<Conversation> GetConversationWith(Guid userID)
        //{
        //    return _context.Conversations
        //        .Include(_ => _.User1)
        //        .Include(_ => _.User2)
        //        .Where(_ => ( _.User1Id == userID && _.User2Id == _userService.CurrentUserId ) || _.User2Id == _userService.CurrentUserId && _.User1Id == userID)
        //        .ToList();
        //}

        //public void SendMessage(Guid ReceiverID, MessageConversation message)
        //{
        //    if( message.Conversation == null)
        //    {
        //        var conversation = new Conversation()
        //        {
        //            User1 = _userService.CurrentUser,
        //            User1Id = _userService.CurrentUserId,
        //            User2 = _userService.Get(ReceiverID),
        //            User2Id = ReceiverID
        //        };
        //        _context.Conversations.Create(conversation);
        //        message.Conversation = conversation;
        //    }
        //    _context.Messages.Create(message);
        //    _context.SaveChanges();
        //}
    }
}
