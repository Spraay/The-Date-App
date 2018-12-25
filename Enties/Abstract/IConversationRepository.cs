using App.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Abstract
{
    public interface IConversationRepository : IEntityBaseRepository<Conversation>
    {
        IEnumerable<Conversation> GetUserConversations(Guid id);
        Message GetLastMessage(Guid id);
    }
}
