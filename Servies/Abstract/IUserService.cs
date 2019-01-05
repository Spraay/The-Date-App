using App.Model.Assigned;
using App.Model.Entities;
using App.Model.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IUserService
    {
        Guid CurrentUserId { get; }
        bool IsFilled(Guid id);
        void Update(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes);
    }
    public partial interface IUserService 
    {
        Task<bool> IsFilledAsync(Guid id);
        Task<List<AssignedInterestData>> PopulateAssignedInterestDataAsync(User user);
        Task UpdateAsync(ApplicationUserViewModel user, string[] selectedInterests, string selectedGender, string selectedEyes);
    }
}
