using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Core.Models.Entities;

namespace Core.Repositories.Abstract
{
    public interface IConversationRepository : IEntityBaseRepository<Conversation>
    {
        Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid id);
    }
}
