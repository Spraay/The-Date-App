using System;

namespace Services
{
    public interface IImageLikeService
    {
        int CountImageLikes(Guid imageID);
        bool IsImageLiked(Guid imageID, Guid userID);
        void ToggleImageLike(Guid imageID, Guid userID);
    }
}