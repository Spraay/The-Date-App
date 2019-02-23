using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
{
    public class FriendRepository : EntityBaseRepository<Friendship>, IFriendRepository
    {
        public FriendRepository(ApplicationDbContext context) : base(context) { }
    }
}
