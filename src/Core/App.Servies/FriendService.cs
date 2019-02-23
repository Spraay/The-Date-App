using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Abstract;
using Core.Models.Entities;
using Core.Models.Enumerations;
using Infrastructure.DAO.Data;
using Core.Repositories.Abstract;

namespace Core.Services
{
    public class FriendService : EntityBaseService<Friendship>, IFriendService
    {
        private readonly IFriendRepository _repository;
        public FriendService(IFriendRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> AreFriendsAsync(Guid userId1, Guid userId2)
        {
            if (await _repository.IsExistsAsync(_ => _.SenderId == userId1 && _.FriendId == userId2) || await _repository.IsExistsAsync(_ => _.SenderId == userId2 && _.FriendId == userId1))
                return true;
            return false;
        }

        public async Task<Friendship> GetFriendshipBetween(Guid userId1, Guid userId2)
        {
            if(await AreFriendsAsync(userId1, userId2))
                return (await _repository.GetSingleAsync(_ => _.FriendId == userId1 && _.SenderId == userId2))
                    ?? (await GetFriendshipBetween(userId2, userId1));
            return null;
        }

        public async Task<IEnumerable<User>> GetUserFriendsAsync(Guid id)
        {
            var friendships = await _repository.FindByAsync(_=>_.Status==Status.Accepted && ( _.FriendId==id || _.SenderId==id), _=>_.Sender, _=>_.Friend );
            var result = friendships.Select(_ => _.Sender).Where(_ => _.Id != id).ToList();
            result.AddRange(friendships.Select(_ => _.Friend).Where(_ => _.Id != id).ToList());
            return result;
        }

        public async Task<IEnumerable<User>> GetUserReceievedInvitationsAsync(Guid id)
        {
            var friendships = await _repository.FindByAsync(_=>_.FriendId==id && _.Status == Status.Pending, _=>_.Sender);
            return friendships.Select(_ => _.Sender);
        }

        public async Task<IEnumerable<User>> GetUserSentInvitationsAsync(Guid id)
        {
            var friendships = await _repository.FindByAsync(_ => _.SenderId == id && _.Status == Status.Pending, _ => _.Friend);
            return friendships.Select(_ => _.Friend);
        }
    }
}

