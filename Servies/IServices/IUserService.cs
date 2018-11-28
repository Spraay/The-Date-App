using Enties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        ApplicationUser CurrentUser { get; }
        Guid CurrentUserId { get; }
        ApplicationUser Get(Guid id);
        Task<ApplicationUser> GetAsync(Guid id);
        void Update(ApplicationUser user);
        void Delete(Guid id);
        List<ApplicationUser> GetList();


        string GetFirstName(Guid id);
        string GetLastName(Guid id);
        string GetEmail(Guid id);
       
        List<Interest> GetInterests(Guid id);
        void UpdateInterests(string[] selectedInterests, Guid id);
        bool IsFilled(Guid id);
        Task<bool> IsFilledAsync(Guid id);
        void Update(ApplicationUser user, string[] selectedInterests, string selectedGender, string selectedEyes);
        bool UserExists(Guid userID);
        Task<List<ApplicationUser>> GetListAsync();

    }
}
