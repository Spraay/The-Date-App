using DAO;
using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using Service.IService.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ConversationService : Service<Conversation, Guid, ApplicationDbContext>, IConversationService
    {
        private readonly ApplicationDbContext _context;
        public ConversationService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Conversation>> GetUserConversations(Guid id)
        {
            return await _context.Conversations
                .Where(_ => _.Users.Select(__ => __.UserId).Contains(id)).ToListAsync();
        }
    }
}
