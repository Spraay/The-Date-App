using Enties;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IImageService
    {
        void Add(string fileName, Guid currentUser, string title, string description);
        void Delete(string src);
        List<Image> GetUserImages(Guid userID);
        Image Get(Guid id);
        bool IsOwner(Guid id, Guid userID);
    }
}
