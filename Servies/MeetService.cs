using App.DAO.Data;
using App.Model.Entities;
using App.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class MeetService : IMeetService
    {
        private readonly ApplicationDbContext _context;

        public MeetService(ApplicationDbContext context) => _context = context;

        public RealMeet Get(Guid whoId, Guid withId) => _context.Meets.SingleOrDefault(_ => _.WhoId == whoId && _.WithId == withId);

        public async Task<RealMeet> GetAsync(Guid whoId, Guid withId) => await _context.Meets.SingleOrDefaultAsync(_ => _.WhoId == whoId && _.WithId == withId);

        public bool IsMeetWith(Guid whoId, Guid withId) => _context.Meets.Any(_ => _.WhoId == whoId && _.WithId == withId);

        public async Task<bool> IsMeetWithAsync(Guid whoId, Guid withId) => await _context.Meets.AnyAsync(_ => _.WhoId == whoId && _.WithId == withId);

        public void SetMeetWith(Guid whoId, Guid withId) => _context.Meets.Add(new RealMeet() { WhoId = whoId, WithId = withId }).Context.SaveChanges();

        public async Task SetMeetWithAsync(Guid whoId, Guid withId)
        {
            if (whoId != withId)
            {
                await _context.Meets.AddAsync(new RealMeet() { WhoId = whoId, WithId = withId });
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<User> UserMeetsAccepted(Guid userId)
        {
            var withUsers = _context.Meets.Where(_ => _.WhoId == userId).Select(_ => _.With);
            var result = new List<User>();
            return withUsers.Where( _ =>  IsMeetWith(userId, _.Id));
        }

        public async Task<IEnumerable<User>> UserMeetsAcceptedAsync(Guid userId)
        {
            var withUsers = await _context.Meets.Where(_ => _.WhoId == userId).Select(_ => _.With).ToListAsync();
            var result = new List<User>();
            foreach(var u in withUsers)
            {
                if (await IsMeetWithAsync(userId, u.Id))
                    result.Add(u);
            }
            return result;
        }

        public IEnumerable<User> UserMeetsRequested(Guid userId)
        {
            return _context.Meets.Where(_ => _.WithId == userId).Select(_ => _.Who);
        }

        public async Task<IEnumerable<User>> UserMeetsRequestedAsync(Guid userId)
        {
            return await _context.Meets.Where(_ => _.WithId == userId).Select(_ => _.Who).ToListAsync();
        }

        public async Task<IEnumerable<User>> UsersMarkedAsMetAsync(Guid userId)
        {
            return await _context.Meets.Where(_ => _.WhoId == userId).Select(_ => _.With).ToListAsync();
        }
    }
}
