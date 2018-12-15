using Enties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IImageService
    {
        void Add(string fileName, Guid currentUser, string title, string description);
        void Delete(string src);
        List<Image> GetUserImages(Guid userID);
        Image Get(Guid id);
        bool IsOwner(Guid id, Guid userID);
        bool IsExists(Guid id);
        void SetProfilePhoto(Guid currentUserId, Guid id);
        void SetProfileBackgroundPhoto(Guid currentUserId, Guid id);
    }

    //TASK PART
    public partial interface IImageService
    {
        Task AddAsync(string fileName, Guid currentUser, string title, string description);
        Task DeleteAsync(string src);
        Task<Image> GetAsync(Guid id);
        Task<bool> IsOwnerAsync(Guid id, Guid userID);
        Task<bool> IsExistsAsync(Guid id);
        Task SetProfilePhotoAsync(Guid currentUserId, Guid id);
        Task SetProfileBackgroundPhotoAsync(Guid currentUserId, Guid id);
    }
}
