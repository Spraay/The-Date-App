using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
{
    public class InterestRepository : EntityBaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
