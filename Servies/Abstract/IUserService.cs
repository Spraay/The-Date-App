using App.Model.Assigned;
using App.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IUserService
    {
        Guid CurrentUserId { get; }
        bool IsFilled(Guid id);
        User Get(Guid id);
        void UpdateEyes(string eyes);
        void UpdateGender(string gender);
        void UpdateInterests(string[] selectedInterests);
        void Update(User user);
        void Update(User user, string[] interests = null, string selectedEyes = null, string selectedGender = null);
        
    }

    public partial interface IUserService 
    {
        Task<User> GetAsync(Guid id);
        Task<bool> IsFilledAsync(Guid id);
        Task UpdateEyesAsync(string eyes);
        Task UpdateGenderAsync(string gender);
        Task UpdateInterestsAsync(string[] selectedInterests);
        Task UpdateAsync(User user);
        Task UpdateAsync(User user, string[] interests = null, string selectedEyes = null, string selectedGender = null);
        Task <List<AssignedInterestData>> PopulateAssignedInterestData(User user);
        Task<User> GetSingleWithAllPropertiesAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
