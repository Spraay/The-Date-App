using App.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IUserRoleService
    {
        IEnumerable<Role> GetUserRoles(Guid id);
        Task<IEnumerable<Role>> GetUserRolesAsync(Guid id);
    }
}
