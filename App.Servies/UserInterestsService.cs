using App.DAO.Data;
using App.Model.Assigned;
using App.Model.Entities;
using App.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class UserInterestsService : IUserInterestsService
    {
        private readonly ApplicationDbContext _context;

        public UserInterestsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id)
        {
            IQueryable<Interest> query = _context.Set<InterestUser>()
                .Where(_ => _.UserId == id)
                .Select(_ => _.Interest);
            return await query.ToListAsync();
        }

        private async Task<IEnumerable<Interest>> GetAllInterestsAsync()
        {
            return await _context.Set<Interest>().ToListAsync();
        }

        private async Task<IEnumerable<Guid>> GetAllInterestsIdsAsync()
        {
            var query = await GetAllInterestsAsync();
            return query.Select(_ => _.Id);
        }

        private async Task<IEnumerable<Guid>> GetUserInterestsIdsAsync(Guid id)
        {
            var query = await GetUserInterestsAsync(id);
            return query.Select(_=>_.Id);
        }

        private async Task AddUserInterestAsync(Guid interestId, Guid userId)
        {
            await _context.Set<InterestUser>().AddAsync(new InterestUser() { InterestId = interestId, UserId = userId });  
        }

        private async Task DeleteUserInterestAsync(Guid interestId, Guid userId)
        {
            var itemToDelete = await _context.Set<InterestUser>().SingleOrDefaultAsync(_ => _.UserId == userId && _.InterestId == interestId);
            _context.Set<InterestUser>().Remove(itemToDelete);
        }

        public async Task UpdateUserInterestsAsync(string[] selectedInterests, Guid id)
        {
            var selectedInterestsHS = new HashSet<string>(selectedInterests);
            var userInterestsHS = new HashSet<Guid>(await GetUserInterestsIdsAsync(id));
            var allInterestsHS = new HashSet<Guid>(await GetAllInterestsIdsAsync());

            foreach (var interest in allInterestsHS)
            {
                if (selectedInterestsHS.Contains(interest.ToString()))
                {
                    if (!userInterestsHS.Contains(interest))
                    {
                        await AddUserInterestAsync(interest, id);
                    }
                }
                else
                {
                    if (userInterestsHS.Contains(interest))
                    {
                        await DeleteUserInterestAsync(interest, id);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<AssignedInterestData>> PopulateAssignedInterestDataAsync(Guid id)
        {
            var userInterestsHS = new HashSet<Guid>(await GetUserInterestsIdsAsync(id));
            var allInterests =await GetAllInterestsAsync();
            var viewModel = new List<AssignedInterestData>();
            foreach (var interest in allInterests)
            {
                viewModel.Add(new AssignedInterestData
                {
                    InterestID = interest.Id,
                    InterestName = interest.Name,
                    Assigned = userInterestsHS.Contains(interest.Id)
                });
            }
            return viewModel;
        }
    }
}
