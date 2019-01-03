﻿using App.DAO;
using App.Model.Entity;
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

        public void AddUserInterest(Guid id, Guid interestId)
        {
            if (GetSingle(_=>_.UserId == id && _.InterestId == interestId) == null)
            {
                Add(new InterestUser { InterestId = interestId, UserId = id });
            }
        }

        public void DeleteUserInterest(Guid id, Guid interest)
        {
            DeleteWhere(_ => _.InterestId == interest && _.UserId == id);
        }

        public void UpdateUserInterest(Guid id, Guid[] interests)
        {
            var userInterests = GetUserInterests(id).Select(_ => _.Id);
            var allInterests = GetAll();
            foreach (var i in allInterests)
            {
                if (interests.Contains(i.Id))
                {
                    if (!userInterests.Contains(i.Id))
                    {
                        AddUserInterest(id, i.Id);
                    }
                }
                else
                {
                    if (userInterests.Contains(i.Id))
                    {
                        DeleteUserInterest(id, i.Id);
                    }
                }
            }
            Commit();
        }

        public IEnumerable<Interest> GetUserInterests(Guid id)
        {
            return FindBy(_ => _.UserId == id).Select(_ => _.Interest);
        }

        public Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task AddUserInterestAsync(Guid id, Guid interest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserInterestAsync(Guid id, Guid interest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserInterestAsync(Guid id, Guid[] interests)
        {
            throw new NotImplementedException();
        }
    }
}
