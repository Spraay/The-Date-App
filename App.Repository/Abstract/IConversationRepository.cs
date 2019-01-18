using System.Collections.Generic;
using App.Model.Entities;
using System;
using System.Threading.Tasks;

namespace App.Repository.Abstract
{
    public interface IConversationRepository : IEntityBaseRepository<Conversation>
    {
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid id);
    }
}
