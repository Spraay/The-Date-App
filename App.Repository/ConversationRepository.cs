﻿using App.DAO;
using App.Model;
using App.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App.Repository
{
    public class ConversationRepository : EntityBaseRepository<Conversation>, IConversationRepository
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
}
