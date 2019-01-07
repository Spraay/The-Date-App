//using App.DAO.Data;
//using App.Model.Entities;
//using App.Service.Abstract;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Service
//{
//    public class VoteService : IVoteService
//    {
//        private readonly ApplicationDbContext _context;

//        public VoteService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public Vote Get(Guid id)
//        {
//            return _context.Votes.FirstOrDefault(_=>_.Id==id);
//        }

//        public async Task<Vote> GetAsync(Guid whoId, Guid forId)
//        {
//            return await _context.Votes.FirstOrDefaultAsync(_ => _.WhoId == whoId && _.ForId == forId);
//        }

//        public int GetStars(Guid whoId, Guid forId)
//        {
//            return _context.Votes.FirstOrDefault(_ => _.WhoId == whoId && _.ForId == forId).Value;
//        }

//        public async Task<int> GetStarsAsync(Guid whoId, Guid forId)
//        {
//            var result = await _context.Votes.FirstOrDefaultAsync(_ => _.WhoId == whoId && _.ForId == forId);
//            return result.Value;
//        }

       
//        public bool VoteExist(Guid whoId, Guid forId)
//        {
//            return _context.Votes.Any(_ => _.WhoId == whoId && _.ForId == forId);
//        }

//        public async Task<bool> VoteExistAsync(Guid whoId, Guid forId)
//        {
//            return await _context.Votes.AnyAsync(_ => _.WhoId == whoId && _.ForId == forId);
//        }

//        public async Task AddAsync(Guid whoId, Guid forId, int Vote)
//        {
//            var meet = await _context.Meets.FirstOrDefaultAsync(_ => _.WhoId == whoId && _.WithId == forId);
//            if (meet!=null)
//            {
//                await _context.Votes.AddAsync(new Vote() { WhoId = whoId, ForId = forId, Meet = meet });
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task UpdateAsync(Guid whoId, Guid forId, int Vote)
//        {
//            if (_context.Meets.Any(_ => _.WhoId == whoId && _.WithId == forId))
//            {
//                var vote = await GetAsync(whoId, forId);
//                _context.Votes.Update(vote);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
