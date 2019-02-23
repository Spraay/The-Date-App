using Infrastructure.DAO.Data;
using Core.Models.Entities;
using Core.Repositories.Abstract;

namespace Core.Repositories
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
