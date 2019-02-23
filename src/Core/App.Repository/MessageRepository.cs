using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
{
    public class MessageRepository : EntityBaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context) { }

    }
}
