using App.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Abstract
{
    public interface IInterestRepository : IEntityBaseRepository<Interest>
    {
        IEnumerable<Interest> GetUserInterests(Guid id);
        void AddUserInterest(Guid id, Guid interest);
        void DeleteUserInterest(Guid id, Guid interest);
    }
}
