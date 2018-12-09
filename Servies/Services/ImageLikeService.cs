using DAO.Data;
using Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ImageLikeService : IImageLikeService
    {
        private readonly ApplicationDbContext _context;

        public ImageLikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ToggleImageLike(Guid imageID, Guid userID)
        {
            if (IsImageLiked(imageID, userID))
            {
                var likeToDel = _context.ImagesLikes.SingleOrDefault(_ => _.LikedItemID == imageID && _.CreatorID == userID);
                _context.ImagesLikes.Remove(likeToDel);

            }
            else
            {
                _context.ImagesLikes.Add(
                    new ImageLike()
                    {
                        LikedItemID = imageID,
                        CreatorID = userID
                    }
                );
            }
            _context.SaveChanges();
        }

        public bool IsImageLiked(Guid imageID, Guid userID)
        {
            return _context.ImagesLikes.Any(_ => _.LikedItemID == imageID && _.CreatorID == userID);
        }

        public int CountImageLikes(Guid imageID)
        {
            return _context.ImagesLikes.Count(_ => _.LikedItemID == imageID);
        }
    }
}
