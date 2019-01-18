using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;

namespace App.Repository
{
    public class ConversationRepository : EntityBaseRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Conversation>> GetUserConversationsAsync(Guid id)
        {
            return await FindByAsync(_ => _.Users.Select(__=>__.UserId).Contains(id), _=>_.Messages, _=>_.Users);
        }
    }
}
