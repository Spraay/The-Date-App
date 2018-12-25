using App;
using App.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IImageService
    {
        void Create(string fileName, Guid currentUser, string title, string description);
        void Delete(string src);
        Image Get(Guid id);
        List<Image> GetList(Guid userID);
        bool IsOwner(Guid id, Guid userID);
        bool IsExists(Guid id);
        void SetProfilePhoto(Guid currentUserId, Guid id);
        void SetProfileBackgroundPhoto(Guid currentUserId, Guid id);
    }

    //TASK PART
    public partial interface IImageService
    {
        Task CreateAsync(string fileName, Guid currentUser, string title, string description);
        Task DeleteAsync(string src);
        Task<Image> GetAsync(Guid id);
        Task<List<Image>> GetListAsync(Guid userID);
        Task<bool> IsOwnerAsync(Guid id, Guid userID);
        Task<bool> IsExistsAsync(Guid id);
        Task SetProfilePhotoAsync(Guid currentUserId, Guid id);
        Task SetProfileBackgroundPhotoAsync(Guid currentUserId, Guid id);
    }
}
