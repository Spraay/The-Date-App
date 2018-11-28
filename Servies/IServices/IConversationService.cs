using System;
using System.Collections.Generic;
using Enties;

namespace Services
{
    public interface IConversationService
    {
        Conversation GetConversation(Guid id, bool isMessagesIncluded = false, bool isConversationUsersIncluded = false);
        List<Conversation> GetUserConversations(Guid userID, bool isMessagesIncluded = false, bool isConversationUsersIncluded = false);
        void SendMessage(Message message);
    }
}