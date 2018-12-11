using Enties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IImageService
    {
        void Add(string fileName, Guid currentUser, string title, string description);
        void Delete(string src);
        List<Image> GetUserImages(Guid userID);
        Image Get(Guid id);
        Task<Image> GetAsync(Guid id);
        bool IsOwner(Guid id, Guid userID);
        Task<bool> IsOwnerAsync(Guid id, Guid userID);
        bool IsExists(Guid id);
        Task<bool> IsExistsAsync(Guid id);
    }
}
