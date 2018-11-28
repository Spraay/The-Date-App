using DAO.Data;
using Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public FriendService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public int Count
        {
            get
            {
                return GetFriendships(_userService.CurrentUserId).Count();
            }
        }

        public bool AreFriends(Guid user1ID, Guid user2ID)
        {
            var asd =  _context.Friendships.Any(_ => _.FriendId == user1ID && _.SenderId == user2ID);
            var asc =  _context.Friendships.Any(_ => _.FriendId == user2ID && _.SenderId == user1ID);
            if (asd || asc)
                return true;
            return false;
            //return _context.Friendships.Any(_ => _.FriendId == user1ID && _.SenderId == user2ID) ? true : _context.Friendships.Any(_ => _.SenderId == user1ID && _.FriendId == user2ID);
        }

        public async Task<bool> AreFriendsAsync(Guid user1ID, Guid user2ID)
        {
            var asd = await _context.Friendships.AnyAsync(_ => _.FriendId == user1ID && _.SenderId == user2ID);
            var asc = await _context.Friendships.AnyAsync(_ => _.FriendId == user2ID && _.SenderId == user1ID);
            if (asd || asc)
                return true;
            return false;
            //return await _context.Friendships.AnyAsync(_ => _.FriendId == user1ID && _.SenderId == user2ID) ? true : await _context.Friendships.AnyAsync(_ => _.SenderId == user1ID && _.FriendId == user2ID);
        }

        public List<Friendship> GetFriendships(Guid userID)
        {
            return _context.Friendships
               .Include(f => f.Friend)
               .Include(f => f.Sender)
               .Where(c => c.FriendId == userID || c.SenderId == userID)
               .Where(c => c.Status == Status.Accepted).ToList();
        }

        public async Task<List<Friendship>> GetFriendshipsAsync(Guid userID)
        {
            return await _context.Friendships
                .Include(f => f.Friend)
                .Include(f => f.Sender)
                .Where(c => c.FriendId == userID || c.SenderId == userID )
                .Where(c=>c.Status == Status.Accepted).ToListAsync();
        }

        public List<Friendship> GetInvitationsSent(Guid userID)
        {
            return _context.Friendships
               .Include(f => f.Friend)
               .Include(f => f.Sender)
               .Where(c => c.SenderId == userID)
               .Where(c => c.Status != Status.Accepted).ToList();
        }

        public Friendship GetUsersFriendsip(Guid user1ID, Guid user2ID)
        {
            var result = _context.Friendships
                .Include(f => f.Friend)
                .Include(f => f.Sender)
                .SingleOrDefault(_ => _.FriendId == user1ID && _.SenderId == user2ID);
            if (result == null)
            {
                return _context.Friendships
                    .Include(f => f.Friend)
                    .Include(f => f.Sender)
                    .SingleOrDefault(_ => _.FriendId == user2ID && _.SenderId == user1ID);
            }
            return result;
        }

        public async Task<Friendship> GetUsersFriendsipAsync(Guid user1ID, Guid user2ID)
        {
            var result = await _context.Friendships.SingleOrDefaultAsync(_ => _.FriendId == user1ID && _.SenderId == user2ID);
            if (result == null)
            {
                return await _context.Friendships.SingleOrDefaultAsync(_ => _.FriendId == user2ID && _.SenderId == user1ID);
            }
            return result;
        }


        public void AcceptInvite(Guid friendID)
        {
            var currentUserId = _userService.CurrentUserId;
            var friendship = GetUsersFriendsip(currentUserId, friendID);
            if( friendship !=null && friendship.SenderId==friendID)
            {
                friendship.Status = Status.Accepted;
                _context.Friendships.Update(friendship);
                _context.SaveChanges();
            }
        }

        public async void AcceptInviteAsync(Guid friendID)
        {
            var currentUserId = _userService.CurrentUserId;
            var friendship = await GetUsersFriendsipAsync(currentUserId, friendID);
            if (friendship != null && friendship.SenderId == friendID)
            {
                friendship.Status = Status.Accepted;
                _context.Friendships.Update(friendship);
                await _context.SaveChangesAsync();
            }
        }

        public void InviteFriend(Guid friendID)
        {
            var currentUserId = _userService.CurrentUserId;
            if ( !AreFriends(currentUserId, friendID) )
            {
                var friendship = new Friendship()
                {
                    Sender = _userService.CurrentUser,
                    Friend = _userService.Get(friendID),
                    SenderId = _userService.CurrentUserId,
                    FriendId = friendID
                };
                _context.Friendships.Add(friendship);
                _context.SaveChanges();
            }
            AcceptInvite(friendID);
        }

        public async void InviteFriendAsync(Guid friendID)
        {
            var currentUserId = _userService.CurrentUserId;
            if (!await AreFriendsAsync(currentUserId, friendID))
            {
                var friendship = new Friendship()
                {
                    Sender = _userService.CurrentUser,
                    Friend = await _userService.GetAsync(friendID)
                };
                await _context.Friendships.AddAsync(friendship);
                await _context.SaveChangesAsync();
            }
            AcceptInviteAsync(friendID);
        }

        public void Remove(Guid user1ID, Guid user2ID)
        {
            var frienship = GetUsersFriendsip(user1ID, user2ID);
            if (frienship != null)
            {
                _context.Friendships.Remove(frienship);
                _context.SaveChanges();
            } 
        }

        public List<Friendship> GetInvitationsReceived(Guid userID)
        {
            
            return _context.Friendships
                .Include(f => f.Friend)
                .Include(f => f.Sender)
                .Where(c => c.FriendId == userID)
                .Where(c => c.Status != Status.Accepted).ToList();
            
        }
    }
}
