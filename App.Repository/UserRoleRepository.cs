using App.DAO;
using App.Model.Entities;
using App.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Role> GetUserRoles(Guid id)
        {
            return FindBy(_ => _.UserId == id).Select(_ => _.Role);
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid id)
        {
            var result = await FindByAsync(_ => _.UserId == id);
            return result.Select(_=>_.Role);
        }
    }
}
