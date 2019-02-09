using App.Model.Entities;
using App.Model.View;
using System;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public interface IUserService : IEntityBaseService<User>
    {
        Guid CurrentUserId { get; }

        Task<bool> IsFilledAsync(Guid id);
      
        Task UpdateAsync(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes);
    }
}
