using App.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using App.Model.Entity;
using App.Repository.Abstract;

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
            return FindBy(_ => _.Users.Select(__=>__.Id).Contains(id));
        }
    }

    public partial class ConversationRepository : EntityBaseRepository<Conversation>, IConversationRepository
    {
        
    }
}
