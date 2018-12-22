using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class InterestService : IInterestService
    {
        private readonly ApplicationDbContext _context;
        public InterestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(string name)
        {
            _context.Interests.Add(new Interest() { Name = name });
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var interest = _context.Interests.Find(id);
            if (interest == null) throw new KeyNotFoundException("Interest with id '"+id.ToString()+"' not exists.");
            _context.Interests.Remove(interest);
            _context.SaveChanges();
        }

        public Interest GetFirstByName(string name)
        {
            var interest = _context.Interests.First( i => i.Name == name);
            if (interest == null) throw new KeyNotFoundException("Interest with name '" + name + "' not exists.");
            return interest;
        }

        public List<Interest> GetList()
        {
            return _context.Interests.ToList();
        }

        public Interest Get(Guid id)
        {
            var interest = _context.Interests.Find(id);
            if (interest == null) throw new KeyNotFoundException("Interest with id '" + id.ToString() + "' not exists.");
            return interest;
        }

        public void Update(Guid id, string name)
        {
            var interest = _context.Interests.Find(id);
            if (interest == null) throw new KeyNotFoundException("Interest with id '" + id.ToString() + "' not exists.");
            interest.Name = name;
            _context.SaveChanges();
        }

        public void Add(Interest interest)
        {
            var interestFromDb = _context.Interests.First(i => i.Name == interest.Name);
            if (interestFromDb != null) throw new DuplicateWaitObjectException();
            _context.Interests.Add(interest);
        }

        public bool Any()
        {
            return _context.Interests.Any();
        }

        public Task<List<Interest>> GetListAsync()
        {
            return _context.Interests
            .ToListAsync();
        }
    }
}
