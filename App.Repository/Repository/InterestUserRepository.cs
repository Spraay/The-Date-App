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

        public async Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id)
        {
            var result = await FindByAsync(_ => _.UserId == id);
            return result.Select(_ => _.Interest);
        }

        public async Task AddUserInterestAsync(Guid id, Guid interest)
        {
            if (await GetSingleAsync(_ => _.UserId == id && _.InterestId == interest) == null)
            {
                await AddAsync(new InterestUser { InterestId = interest, UserId = id });
            }
        }

        public async Task DeleteUserInterestAsync(Guid id, Guid interest)
        {
            await DeleteWhereAsync(_ => _.InterestId == interest && _.UserId == id);
        }

        public async Task UpdateUserInterestAsync(Guid id, Guid[] interests)
        {
            var userInterests = await GetUserInterestsAsync(id);
            var allInterests = await GetAllAsync();
            foreach (var i in allInterests)
            {
                if (interests.Contains(i.Id))
                {
                    if (!userInterests.Select(_=>_.Id).Contains(i.Id))
                    {
                        await AddUserInterestAsync(id, i.Id);
                    }
                }
                else
                {
                    if (userInterests.Select(_ => _.Id).Contains(i.Id))
                    {
                        await DeleteUserInterestAsync(id, i.Id);
                    }
                }
            }
            await CommitAsync();
        }
    }
}
