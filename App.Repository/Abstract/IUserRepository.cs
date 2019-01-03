using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Repository.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsEmailUniq(string email);
        bool IsUsernameUniq(string username);
    }
}
