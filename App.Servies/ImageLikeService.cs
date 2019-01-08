using App.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Model.Entities;
using App.DAO.Data;

namespace App.Service
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
                var likeToDel = _context.ImagesLikes.SingleOrDefault(_ => _.LikedItemId == imageID && _.CreatorId == userID);
                _context.ImagesLikes.Remove(likeToDel);

            }
            else
            {
                _context.ImagesLikes.Add(
                    new ImageLike()
                    {
                        LikedItemId = imageID,
                        CreatorId = userID
                    }
                );
            }
            _context.SaveChanges();
        }

        public bool IsImageLiked(Guid imageID, Guid userID)
        {
            return _context.ImagesLikes.Any(_ => _.LikedItemId == imageID && _.CreatorId == userID);
        }

        public int CountImageLikes(Guid id)
        {
            return _context.ImagesLikes.Count(_ => _.LikedItemId == id);
        }

        public int CountUserImageLikes(Guid id)
        {
            var userImagesIds =  _context.Images.Where(_ => _.UserId == id).Select(_ => _.Id).ToList();
            return  _context.ImagesLikes.Where(_ => userImagesIds.Contains(_.Id)).Count();
        }

    }
    //TASK PART
    public partial class ImageLikeService : IImageLikeService
    {
        public async Task<int> CountImageLikesAsync(Guid id)
        {
            return await _context.ImagesLikes.CountAsync(_ => _.LikedItemId == id);
        }
        public async Task<int> CountUserImageLikesAsync(Guid id)
        {
            var userImagesIds = await _context.Images.Where(_ => _.UserId == id).Select(_ => _.Id).ToListAsync();
            return await _context.ImagesLikes.Where(_ => userImagesIds.Contains(_.Id)).CountAsync();
        }
    }
}
