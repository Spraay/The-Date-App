using App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using App.Model.Entities;
using App.Repository.Abstract;
using App.DAO.Data;

namespace App.Repository
{
    public partial class ConversationRepository : EntityBaseRepository<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Message GetLastMessage(Guid id)
        {
            return GetSingle(_ => _.Id == id, _ => _.Messages).Messages.LastOrDefault();
        }

        public IEnumerable<Conversation> GetUserConversations(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public partial class ConversationRepository : EntityBaseRepository<Conversation>, IConversationRepository
    {
        
    }
}
