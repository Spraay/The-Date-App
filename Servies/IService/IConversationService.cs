using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IConversationService : IService<Conversation, Guid, ChatDbContext>
    {
        Task<ICollection<Conversation>> GetUserConversations(Guid id);
    }
}
