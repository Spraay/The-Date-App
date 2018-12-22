using DAO;
using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.IService.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MessageService : Service<Message, Guid, ApplicationDbContext>, IMessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
