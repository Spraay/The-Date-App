using System;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public partial interface IImageLikeService
    {
        int Count(Guid id);

        bool IsLiked(Guid id);

        Task<bool> IsLikedAsync(Guid id);

        void ToggleLike(Guid imageID, Guid userID);

        Task ToggleLikeAsync(Guid imageID, Guid userID);

        bool IsLikedBy(Guid id, Guid userId);

        Task<bool> IsLikedByAsync(Guid id, Guid userId);
    }
}