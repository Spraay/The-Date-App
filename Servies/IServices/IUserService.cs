using Enties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IUserService
    {
        Guid CurrentUserId { get; }
        ApplicationUser Get(Guid id);
        
        void Update(ApplicationUser user);
        void Delete(Guid id);
        List<ApplicationUser> GetList();
        List<Interest> GetInterests(Guid id);
        void UpdateInterests(string[] selectedInterests, Guid id);
        bool IsFilled(Guid id);
        void Update(ApplicationUser user, string[] selectedInterests, string selectedGender, string selectedEyes);
        bool UserExists(Guid userID);
    }
    public partial interface IUserService
    {
        Task<bool> IsFilledAsync(Guid id);
        Task<ApplicationUser> GetAsync(Guid id);
        Task<List<ApplicationUser>> GetListAsync();
    }
}
