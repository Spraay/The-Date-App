using DAO;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MessageService : Service<Message, Guid, ChatDbContext>, IMessageService
    {
        private readonly ChatDbContext _context;
        public MessageService(ChatDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
