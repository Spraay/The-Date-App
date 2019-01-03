using App;
using App.Abstract;
using App.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IUserService : IUserRepository
    {
        Guid CurrentUserId { get; }
        bool IsFilled(Guid id);
        void UpdateEyes(string eyes);
        void UpdateGender(string gender);
    }

    public partial interface IUserService : IUserRepository
    {
        Task<bool> IsFilledAsync(Guid id);
    }
}
