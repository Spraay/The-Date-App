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

        public void AddUserInterest(Guid id, Guid interestId)
        {
            var interest = GetSingle(_ => _.Id == id, _ => _.Users);
            if (!GetUserInterests(id).Contains(interest))
            {
                interest.Users.Add(new InterestUser() { UserId = id, InterestId = interestId });
                Commit();
            }
        }

        public void DeleteUserInterest(Guid id, Guid interest)
        {
            var Interest = GetSingle(_ => _.Id == id, _ => _.Users);
            var InterestUser = Interest.Users.SingleOrDefault(_ => _.UserId == id);
            if (InterestUser != null)
            {
                Interest.Users.Remove(InterestUser);
                Commit();
            }
        }

        public void UpdateUserInterest(Guid id, Guid[] interests)
        {
            var userInterests = GetUserInterests(id).Select(_ => _.Id);
            var allInterests = GetAll();
            foreach (var i in allInterests)
            {
                if (interests.Contains(i.Id))
                {
                    if (!userInterests.Contains(i.Id))
                    {
                        AddUserInterest(id, i.Id);
                    }
                }
                else
                {
                    if (userInterests.Contains(i.Id))
                    {
                        DeleteUserInterest(id, i.Id);
                    }
                }
            }
        }

        public IEnumerable<Interest> GetUserInterests(Guid id)
        {
            return FindBy(_=>_.Users.Any(__=>__.UserId==id));
        }
    }
}
