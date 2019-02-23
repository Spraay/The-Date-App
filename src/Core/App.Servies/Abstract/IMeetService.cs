using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IMeetService
    {
        RealMeet Get(Guid whoId, Guid withId);
        bool IsMeetWith(Guid whoId, Guid withId);
        void SetMeetWith(Guid whoId, Guid withId);
        IEnumerable<User> UserMeetsAccepted(Guid userId);
        IEnumerable<User> UserMeetsRequested(Guid userId);

        Task<RealMeet> GetAsync(Guid whoId, Guid withId);
        Task<bool> IsMeetWithAsync(Guid whoId, Guid withId);
        Task SetMeetWithAsync(Guid whoId, Guid withId);
        Task<IEnumerable<User>> UserMeetsAcceptedAsync(Guid userId);
        Task<IEnumerable<User>> UserMeetsRequestedAsync(Guid userId);
        Task<IEnumerable<User>> UsersMarkedAsMetAsync(Guid userId);
        Task<int> UserMeetsAcceptedCountAsync(Guid id);
    }
}
