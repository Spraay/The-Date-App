using App.Model.Entity;

namespace App.Repository.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsEmailUniq(string email);
        bool IsUsernameUniq(string username);
    }
}
