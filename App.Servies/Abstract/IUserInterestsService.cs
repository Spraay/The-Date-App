using App.Model.Assigned;
using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IUserInterestsService
    {
        Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id);

        Task UpdateUserInterestsAsync(string[] selectedInterests, Guid id);

        Task<List<AssignedInterestData>> PopulateAssignedInterestDataAsync(Guid id);
    }
}
