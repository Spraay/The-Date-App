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
            if ( IsImageLiked(imageID, userID) )
            {
                var likeToDel = _context.ImagesLikes.SingleOrDefault(_ => _.ImageID == imageID && _.UserWhoLikedID == userID);
                _context.ImagesLikes.Remove(likeToDel);
                
            }
            else
            {
                _context.ImagesLikes.Add(
                    new ImageLike()
                    {
                        ImageID = imageID,
                        UserWhoLikedID = userID
                    }
                );
            }
            _context.SaveChanges();
        }

        public bool IsImageLiked(Guid imageID, Guid userID)
        {
            return _context.ImagesLikes.Any(_ => _.ImageID == imageID && _.UserWhoLikedID == userID);
        }

        public int CountImageLikes(Guid imageID)
        {
            return _context.ImagesLikes.Count(_ => _.ImageID == imageID);
        }
    }
}
