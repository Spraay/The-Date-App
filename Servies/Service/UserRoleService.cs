using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public IEnumerable<Role> GetUserRoles(Guid id)
        {
            return _userRoleRepository.GetUserRoles(id);
        }

        public async Task<IEnumerable<Role>> GetUserRolesAsync(Guid id)
        {
            return await _userRoleRepository.GetUserRolesAsync(id);
        }
    }
}
