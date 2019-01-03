using System.Collections.Generic;
using App.Model.Entity;
using System;

namespace App.Repository.Abstract
{
    public interface IConversationRepository : IEntityBaseRepository<Conversation>
    {
        IEnumerable<Conversation> GetUserConversations(Guid id);
        Message GetLastMessage(Guid id);
    }
}
