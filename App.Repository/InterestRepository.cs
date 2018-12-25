using App.DAO;
using App.Model;
using App.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Repository
{
    public class InterestRepository : EntityBaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddUserInterest(Guid id, Guid interest)
        {
            var Interest = GetSingle(_ => _.Id == id, _ => _.Users);
            Interest.Users.Add(new InterestUser() { UserId = id });
            Commit();
        }

        public void DeleteUserInterest(Guid id, Guid interest)
        {
            var Interest = GetSingle(_ => _.Id == id, _ => _.Users);
            var InterestUser = Interest.Users.SingleOrDefault(_ => _.UserId == id);
            Interest.Users.Remove(InterestUser);
            Commit();
        }

        public IEnumerable<Interest> GetUserInterests(Guid id)
        {
            return FindBy(_ => _.Users.Select(__ => __.Id).Contains(id));
        }
    }
}
