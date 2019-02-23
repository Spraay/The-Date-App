using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
{
    public class VoteRepository : EntityBaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext context) : base(context) { }

       
    }
}
