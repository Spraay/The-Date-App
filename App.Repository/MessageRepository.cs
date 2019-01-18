using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;

namespace App.Repository
{
    public class MessageRepository : EntityBaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context) { }

    }
}
