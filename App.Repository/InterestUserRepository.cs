using App.DAO;
using App.Model.Entities;
using App.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository
{
    public class InterestUserRepository : EntityBaseRepository<InterestUser>, IInterestUserRepository
    {
        public InterestUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
