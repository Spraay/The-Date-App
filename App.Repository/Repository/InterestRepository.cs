using App.DAO;
using App.Model.Entities;
using App.Repository.Abstract;

namespace App.Repository
{
    public class InterestRepository : EntityBaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
