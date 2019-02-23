using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Abstract;
using Core.Models.Entities;
using Infrastructure.DAO.Data;

namespace Core.Services
{
    public partial class ImageLikeService : IImageLikeService
    {
        private readonly ApplicationDbContext _context;

        public ImageLikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ToggleLike(Guid id, Guid userId)
        {
            if (IsLikedBy(id, userId))
            {
                var likeToDel = _context.ImagesLikes.SingleOrDefault(_ => _.LikedItemId == id && _.CreatorId == userId);
                _context.ImagesLikes.Remove(likeToDel);

            }
            else
            {
                _context.ImagesLikes.Add(
                    new ImageLike()
                    {
                        LikedItemId = id,
                        CreatorId = userId
                    }
                );
            }
            _context.SaveChanges();
        }

        public async Task ToggleLikeAsync(Guid id, Guid userId)
        {
            if (await IsLikedByAsync(id, userId))
            {
                var likeToDel = await _context.ImagesLikes.SingleOrDefaultAsync(_ => _.LikedItemId == id && _.CreatorId == userId);
                _context.ImagesLikes.Remove(likeToDel);
            }
            else
            {
                await _context.ImagesLikes.AddAsync(
                    new ImageLike()
                    {
                        LikedItemId = id,
                        CreatorId = userId
                    }
                );
            }
            await _context.SaveChangesAsync();
        }

        public bool IsLiked(Guid id)
        {
            return _context.ImagesLikes.Any(_ => _.LikedItemId == id);
        }

        public async Task<bool> IsLikedAsync(Guid id)
        {
            return await _context.ImagesLikes.AnyAsync(_ => _.LikedItemId == id);
        }

        public int Count(Guid id)
        {
            return _context.ImagesLikes.Count(_ => _.LikedItemId == id);
        }

        public bool IsLikedBy(Guid id, Guid userId)
        {
            return _context.ImagesLikes.Any(_ => _.LikedItemId == id && _.CreatorId == userId);
        }

        public async Task<bool> IsLikedByAsync(Guid id, Guid userId)
        {
            return await _context.ImagesLikes.AnyAsync(_ => _.LikedItemId == id && _.CreatorId == userId);
        }
    }
}
