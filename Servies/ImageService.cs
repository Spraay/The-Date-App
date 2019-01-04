using App.DAO;
using App;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Service.Abstract;
using App.Model.Entities;

namespace App.Service
{
    public partial class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;

        public ImageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Image Get(Guid id)
        {
            return _context.Images
                .Include(_ => _.Likes)
                .SingleOrDefault(_ => _.Id == id);
        }

        public List<Image> GetList(Guid userID)
        {
            return _context.Images.Where(_ => _.UserId == userID).ToList();
        }

        public void Create(string src, Guid userID, string title, string desc)
        {
            _context.Images.Add(new Image()
            {
                Src = src,
                UserId = userID,
                Title = title,
                Description = desc,
            });
            _context.SaveChanges();
        }

        public void Delete(string src)
        {
            var imgToRemove = _context.Images.SingleOrDefault(_ => _.Src == src);
            _context.Images.Remove(imgToRemove);
            _context.SaveChanges();
        }

        public bool IsExists(Guid id)
        {
            return _context.Images.Any(_ => _.Id == id);
        }

        public bool IsOwner(Guid id, Guid userID)
        {
            return Get(id).UserId == userID ? true : false;
        }

        public void SetProfilePhoto(Guid currentUserId, Guid id)
        {
            if (_context.Images.Any(_ => _.Id == id))
            {
                var user = _context.Users.SingleOrDefault(_ => _.Id == currentUserId);
                user.ProfileImageSrc = Get(id).Src;
                _context.SaveChanges();
            }
        }
        public void SetProfileBackgroundPhoto(Guid currentUserId, Guid id)
        {
            if (_context.Images.Any(_ => _.Id == id))
            {
                var user = _context.Users.SingleOrDefault(_ => _.Id == currentUserId);
                user.BackgroundImageSrc = Get(id).Src;
                _context.SaveChanges();
            }
        }
    }

    //TASK PART
    public partial class ImageService : IImageService
    {
        public async Task<Image> GetAsync(Guid id)
        {
            return await _context.Images
                .Include(_ => _.Likes)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<List<Image>> GetListAsync(Guid userID)
        {
            return await _context.Images
                .Include(_ => _.Likes)
                .Where(_ => _.UserId == userID).ToListAsync();
        }

        public async Task CreateAsync(string src, Guid userID, string title, string desc)
        {
            await _context.Images.AddAsync(new Image()
            {
                Src = src,
                UserId = userID,
                Title = title,
                Description = desc,
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string src)
        {
            var imgToRemove = await _context.Images.SingleOrDefaultAsync(_ => _.Src == src);
            _context.Images.Remove(imgToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await _context.Images.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> IsOwnerAsync(Guid id, Guid userID)
        {
            var result = await GetAsync(id);
            return result.UserId == userID ? true : false;
        }

        public async Task SetProfilePhotoAsync(Guid currentUserId, Guid id)
        {
            if (await _context.Images.AnyAsync(_ => _.Id == id))
            {
                var user = await _context.Users.SingleOrDefaultAsync(_ => _.Id == currentUserId);
                var img = await GetAsync(id);
                user.ProfileImageSrc = img.Src;
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetProfileBackgroundPhotoAsync(Guid currentUserId, Guid id)
        {
            if (await _context.Images.AnyAsync(_ => _.Id == id))
            {
                var user = await _context.Users.SingleOrDefaultAsync(_ => _.Id == currentUserId);
                var img = await GetAsync(id);
                user.BackgroundImageSrc = img.Src;
                await _context.SaveChangesAsync();
            }
        }
    }
}
