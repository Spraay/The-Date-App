using DAO;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ConversationService : Service<Conversation, Guid, ChatDbContext>, IConversationService
    {
        private readonly ChatDbContext _context;
        public ConversationService(ChatDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Conversation>> GetUserConversations(Guid id)
        {
            return await _context.Conversations
                .Where(_ => _.Users.Select(__ => __.UserID).Contains(id)).ToListAsync();
        }
    }
}
