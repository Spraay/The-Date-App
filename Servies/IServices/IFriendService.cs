using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enties;

namespace Services
{
    public partial interface IFriendService
    {
        Friendship Get(Guid id1, Guid id2);
        bool AreFriends(Guid id1, Guid id2);
        List <ApplicationUser> GetUserFriends(Guid id);
        List <Friendship> GetInvitationsSent(Guid id);
        List <Friendship> GetInvitationsReceived(Guid id);
        void AddFriend(Guid id1, Guid id2);
        void DeleteFriend(Guid id1, Guid id2);
    }

    //TASK PART
    public partial interface IFriendService 
    {
        Task<Friendship> GetAsync(Guid id1, Guid id2);
        Task <bool> AreFriendsAsync(Guid id1, Guid id2);
        Task <List<ApplicationUser>> GetUserFriendsAsync(Guid id);
        Task <List<Friendship>> GetInvitationsSentAsync(Guid id);
        Task <List<Friendship>> GetInvitationsReceivedAsync(Guid id);
        Task AddFriendAsync(Guid id1, Guid id2);
        Task DeleteFriendAsync(Guid id1, Guid id2);
    }
}