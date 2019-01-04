using System.Collections.Generic;
using App.Model.Entities;
using System;

namespace App.Repository.Abstract
{
    public interface IConversationRepository : IEntityBaseRepository<Conversation>
    {
        IEnumerable<Conversation> GetUserConversations(Guid id);
        Message GetLastMessage(Guid id);
    }
}
