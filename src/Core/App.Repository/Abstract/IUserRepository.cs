using Core.Models.Entities;

namespace Core.Repositories.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsEmailUniq(string email);
        bool IsUsernameUniq(string username);
    }
}
