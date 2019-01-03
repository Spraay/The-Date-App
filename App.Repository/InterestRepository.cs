using App.DAO;
using App.Model;
using App.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Repository
{
    public class InterestRepository : EntityBaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
