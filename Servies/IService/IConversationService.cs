using DAO;
using DAO.Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IConversationService : IService<Conversation, Guid, ApplicationDbContext>
    {
        Task<ICollection<Conversation>> GetUserConversations(Guid id);
    }
}
