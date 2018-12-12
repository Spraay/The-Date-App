using System;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IImageLikeService
    {
        int CountImageLikes(Guid id);
        bool IsImageLiked(Guid imageID, Guid userID);
        void ToggleImageLike(Guid imageID, Guid userID);
        int CountUserImageLikes(Guid id);
    }

    // TASK PART
    public partial interface IImageLikeService
    {
        Task<int> CountImageLikesAsync(Guid imageID);
        //bool IsImageLikedAsync(Guid imageID, Guid userID);
        //void ToggleImageLikeAsync(Guid imageID, Guid userID);
        Task<int> CountUserImageLikesAsync(Guid id);
    }
}