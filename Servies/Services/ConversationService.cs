using DAO.Data;
using Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ConversationService : IConversationService
    {

        private readonly ApplicationDbContext _context;
        //private readonly IUserService _userService;

        public ConversationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Conversation GetConversation(
            Guid id,
            bool isMessagesIncluded = false,
            bool isConversationUsersIncluded = false
            )
        {
            if (isMessagesIncluded && isConversationUsersIncluded)
            {
                return _context.Conversations
                    //.Include(_ => _.Messages)
                    .Include(_ => _.ConversationUsers)
                    .SingleOrDefault(_ => _.ID == id);
            }
            if (isConversationUsersIncluded)
            {
                return _context.Conversations
                    .Include(_ => _.ConversationUsers)
                    .SingleOrDefault(_ => _.ID == id);
            }
            if (isMessagesIncluded)
            {
                return _context.Conversations
                    //.Include(_ => _.Messages)
                    .SingleOrDefault(_ => _.ID == id);
            }
            return _context.Conversations
                    .SingleOrDefault(_ => _.ID == id);
        }

        public List<Conversation> GetUserConversations(
            Guid userID,
            bool isMessagesIncluded = false,
            bool isConversationUsersIncluded = false)
        {
            if (isMessagesIncluded && isConversationUsersIncluded)
            {
                return _context.Conversations
                    //.Include(_ => _.Messages)
                    .Include(_ => _.ConversationUsers)
                    .Where(_ => _.ConversationUsers.Any(__ => __.UserID == userID)).ToList(); 
            }
            if (isConversationUsersIncluded)
            {
           
                return _context.Conversations
                    .Include(_ => _.ConversationUsers)
                    .Where(_ => _.ConversationUsers.Any(__ => __.UserID == userID)).ToList();
            }
            if (isMessagesIncluded)
            {
                return _context.Conversations
                    //.Include(_ => _.Messages)
                    .Where(_ => _.ConversationUsers.Any(__ => __.UserID == userID)).ToList();
            }
            return _context.Conversations.Where(_ => _.ConversationUsers.Any(__ => __.UserID == userID)).ToList();
        }

        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }
    }
}
