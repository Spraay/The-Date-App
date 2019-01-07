using App.DAO;
using App.DAO.Data;
using App.Model.Entities;
using App.Repository.Abstract;

namespace App.Repository
{
    public class VoteRepository : EntityBaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext context) : base(context) { }

       
    }
}
