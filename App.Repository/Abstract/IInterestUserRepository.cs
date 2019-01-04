using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Repository.Abstract
{
    public partial interface IInterestUserRepository : IEntityBaseRepository<InterestUser>
    {
        IEnumerable<Interest> GetUserInterests(Guid id);
        void AddUserInterest(Guid id, Guid interest);
        void DeleteUserInterest(Guid id, Guid interest);
        void UpdateUserInterest(Guid id, Guid[] interests);
    }

    public partial interface IInterestUserRepository : IEntityBaseRepository<InterestUser>
    {
        Task<IEnumerable<Interest>> GetUserInterestsAsync(Guid id);
        Task AddUserInterestAsync(Guid id, Guid interest);
        Task DeleteUserInterestAsync(Guid id, Guid interest);
        Task UpdateUserInterestAsync(Guid id, Guid[] interests);
    }
}
