using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enties;

namespace Services
{
    public interface IFriendService
    {
        int Count { get; }
        bool AreFriends(Guid user1ID, Guid user2ID);
        Task<bool> AreFriendsAsync(Guid user1ID, Guid user2ID);

        List<Friendship> GetFriendships(Guid userID);
        Task<List<Friendship>> GetFriendshipsAsync(Guid userID);
        void InviteFriend(Guid friendID);
        void InviteFriendAsync(Guid friendID);

        Friendship GetUsersFriendsip(Guid user1ID, Guid user2ID);
        Task<Friendship> GetUsersFriendsipAsync(Guid user1ID, Guid user2ID);

        void AcceptInvite(Guid friendID);
        void AcceptInviteAsync(Guid friendID);
        List<Friendship> GetInvitationsSent(Guid userID);
        List<Friendship> GetInvitationsReceived(Guid userID);
        void Remove(Guid user1ID, Guid user2ID);

        
    }
}