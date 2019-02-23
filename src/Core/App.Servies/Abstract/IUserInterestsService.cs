using Core.Models.Assigned;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IUserInterestsService
    {
        Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id);

        Task UpdateUserInterestsAsync(string[] selectedInterests, Guid id);

        Task<List<AssignedInterestData>> PopulateAssignedInterestDataAsync(Guid id);
    }
}
