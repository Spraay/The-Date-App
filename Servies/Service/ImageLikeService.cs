using DAO.Data;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class ImageLikeService : IImageLikeService
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

        public int CountImageLikes(Guid id)
        {
            return _context.ImagesLikes.Count(_ => _.LikedItemID == id);
        }

        public int CountUserImageLikes(Guid id)
        {
            var userImagesIds =  _context.Images.Where(_ => _.UserID == id).Select(_ => _.ID).ToList();
            return  _context.ImagesLikes.Where(_ => userImagesIds.Contains(_.ID)).Count();
        }

    }
    //TASK PART
    public partial class ImageLikeService : IImageLikeService
    {
        public async Task<int> CountImageLikesAsync(Guid id)
        {
            return await _context.ImagesLikes.CountAsync(_ => _.LikedItemID == id);
        }
        public async Task<int> CountUserImageLikesAsync(Guid id)
        {
            var userImagesIds = await _context.Images.Where(_ => _.UserID == id).Select(_ => _.ID).ToListAsync();
            return await _context.ImagesLikes.Where(_ => userImagesIds.Contains(_.ID)).CountAsync();
        }
    }
}
