using Core.Models.Entities;
using Core.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IUserService : IEntityBaseService<User>
    {
        Guid CurrentUserId { get; }

        Task<bool> IsFilledAsync(Guid id);
      
        Task UpdateAsync(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes);
    }
}
