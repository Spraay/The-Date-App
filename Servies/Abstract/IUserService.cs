using App;
using App.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IUserService
    {
        Guid CurrentUserId { get; }
        User Get(Guid id);
        void Update(User user);
        void Delete(Guid id);
        List<User> GetList();
       
        void UpdateInterests(string[] selectedInterests, Guid id);
        bool IsFilled(Guid id);
        void Update(User user, string[] selectedInterests, string selectedGender, string selectedEyes);
        bool UserExists(Guid userID);
    }
    public partial interface IUserService
    {
        Task<bool> IsFilledAsync(Guid id);
        Task<User> GetAsync(Guid id);
        Task<List<User>> GetListAsync();
    }
}
