using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;

namespace App.Repository
{
    public class FriendRepository : EntityBaseRepository<Friendship>, IFriendRepository
    {
        public FriendRepository(ApplicationDbContext context) : base(context) { }
    }
}
