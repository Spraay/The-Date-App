using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public partial class FriendService : IFriendService
    {
        private readonly ApplicationDbContext _context;
        public FriendService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Friendship Get(Guid id1, Guid id2)
        {
            var friendship = _context.Friendships
                .Include(f => f.Friend)
                .Include(f => f.Sender)
                .SingleOrDefault(_ => _.FriendId == id1 && _.SenderId == id2);
            if (friendship == null)
            {
                _context.Friendships
                    .Include(f => f.Friend)
                    .Include(f => f.Sender)
                    .SingleOrDefault(_ => _.FriendId == id2 && _.SenderId == id1);
            }
            return friendship;
        }

        public void AddFriend(Guid id1, Guid id2)
        {
            if (AreFriends(id1, id2))
            {
                var friendship = Get(id1, id2);
                if(friendship.FriendId == id1)
                {
                    friendship.Status = Status.Accepted;
                    _context.Update(friendship);
                    _context.SaveChanges();
                }
            }
            else
            {
                _context.Friendships.Add(new Friendship()
                {
                    SenderId = id1,
                    FriendId = id2
                });
                _context.SaveChanges();
            }  
        }

        public bool AreFriends(Guid id1, Guid id2)
        {
            if (_context.Friendships.Any(_ => _.FriendId == id1 && _.SenderId == id2))
                return true;
            return _context.Friendships.Any(_ => _.FriendId == id2 && _.SenderId == id1);
        }

        public void DeleteFriend(Guid id1, Guid id2)
        {
            _context.Friendships.Remove(Get(id1,id2));
            _context.SaveChanges();
        }
        public List<Friendship> GetInvitationsReceived(Guid id)
        {
            return _context.Friendships
               .Include(f => f.Friend)
               .Include(f => f.Sender)
               .Where(c => c.FriendId == id)
               .Where(c => c.Status != Status.Accepted).ToList();
        }

        public List<Friendship> GetInvitationsSent(Guid id)
        {
            return _context.Friendships
               .Include(f => f.Friend)
               .Include(f => f.Sender)
               .Where(c => c.SenderId == id)
               .Where(c => c.Status != Status.Accepted).ToList();
        }

        public List<User> GetUserFriends(Guid userID)
        {
            var x = _context.Friendships
                .Where(_ => _.SenderId == userID && _.Status == Status.Accepted)
                .Include(f => f.Friend)
                .Select(_ => _.Friend).ToList();

            var y = _context.Friendships
                .Where(_ => _.FriendId == userID && _.Status == Status.Accepted)
                .Include(f => f.Sender)
                .Select(_ => _.Sender).ToList();

            x.AddRange(y);
            return x;
        }

    }

    //TASK PART
    public partial class FriendService : IFriendService
    {
        public async Task<Friendship> GetAsync(Guid id1, Guid id2)
        {
            var friendship = await _context.Friendships
                .Include(f => f.Friend)
                .Include(f => f.Sender)
                .SingleOrDefaultAsync(_ => _.FriendId == id1 && _.SenderId == id2);
                
            if (friendship == null)
            {
                return await _context.Friendships
                    .Include(f => f.Friend)
                    .Include(f => f.Sender)
                    .SingleOrDefaultAsync(_ => _.FriendId == id2 && _.SenderId == id1);
            }
            return friendship;
        }

        public async Task AddFriendAsync(Guid id1, Guid id2)
        {
            await _context.Friendships.AddAsync(new Friendship()
            {
                SenderId = id1,
                FriendId = id2
            });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AreFriendsAsync(Guid id1, Guid id2)
        {
            if ( await _context.Friendships.AnyAsync(_ => _.FriendId == id1 && _.SenderId == id2))
                return true;
            return await _context.Friendships.AnyAsync(_ => _.FriendId == id2 && _.SenderId == id1);
        }

        public async Task DeleteFriendAsync(Guid id1, Guid id2)
        {
            var friendship = await GetAsync(id1, id2);
            _context.Friendships.Remove(friendship);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Friendship>> GetInvitationsReceivedAsync(Guid id)
        {
            return await _context.Friendships
              .Include(f => f.Friend)
              .Include(f => f.Sender)
              .Where(c => c.FriendId == id)
              .Where(c => c.Status != Status.Accepted).ToListAsync();
        }

        public async Task<List<Friendship>> GetInvitationsSentAsync(Guid id)
        {
            return await _context.Friendships
               .Include(f => f.Friend)
               .Include(f => f.Sender)
               .Where(c => c.SenderId == id)
               .Where(c => c.Status != Status.Accepted).ToListAsync();
        }

        public async Task<List<User>> GetUserFriendsAsync(Guid id)
        {
            var x = await _context.Friendships
                .Where(_ => _.SenderId == id && _.Status == Status.Accepted)
                .Include(f => f.Friend)
                .Select(_ => _.Friend)
                .ToListAsync();

            var y = await _context.Friendships
                .Where(_ => _.FriendId == id && _.Status == Status.Accepted)
                .Include(f => f.Sender)
                .Select(_ => _.Sender)
                .ToListAsync();

            x.AddRange(y);
            return x;
        }
    }
}

