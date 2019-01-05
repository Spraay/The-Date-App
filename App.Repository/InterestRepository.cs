using App.DAO;
using App.Model.Entities;
using App.Repository.Abstract;
using System;
using System.Collections.Generic;

namespace App.Repository
{
    public class InterestRepository : EntityBaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
