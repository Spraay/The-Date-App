
using App.Abstract;
using App.DAO;
using App.Model;
using App.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Repository
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public bool IsEmailUniq(string email)
        {
            return (FindBy(_ => _.Email == email) == null) ? false : true;
        }

        public bool IsUsernameUniq(string username)
        {
            return (FindBy(_ => _.UserName == username) == null) ? false : true;
        }
    }
}
