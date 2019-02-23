using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Entities;

namespace Core.Services.Abstract
{
    public interface IFriendService : IEntityBaseService<Friendship> 
    {
        Task<Friendship> GetFriendshipBetween(Guid userId1, Guid userId2);
        Task<IEnumerable<User>> GetUserFriendsAsync(Guid id);
        Task<IEnumerable<User>> GetUserSentInvitationsAsync(Guid id);
        Task<IEnumerable<User>> GetUserReceievedInvitationsAsync(Guid id);
        Task<bool> AreFriendsAsync(Guid userId1, Guid userId2);
    }
}