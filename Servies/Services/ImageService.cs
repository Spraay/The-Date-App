
using DAO.Data;
using Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public partial class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public ImageService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public void Add(string src, Guid userID, string title, string desc)
        {
            _context.Images.Add(new Image()
            {
                Src = src,
                User = _userService.Get(userID),
                Title = title,
                Description = desc,

            });
            _context.SaveChanges();
        }

        public Task AddAsync(string fileName, Guid currentUser, string title, string description)
        {
            throw new NotImplementedException();
        }

        public void Delete(string src)
        {
            var imgToRemove = _context.Images.SingleOrDefault(_ => _.Src == src);
            _context.Images.Remove(imgToRemove);
            _context.SaveChanges();
        }

        public Task DeleteAsync(string src)
        {
            throw new NotImplementedException();
        }

        public Image Get(Guid id)
        {
            return _context.Images
                .Include(_ => _.Likes)
                .SingleOrDefault(_ => _.ID == id);
        }
        public List<Image> GetUserImages(Guid userID)
        {
            return _context.Images.Where(_ => _.UserID == userID).ToList();
        }
        public bool IsExists(Guid id)
        {
            return _context.Images.Any(_ => _.ID == id);
        }
        public bool IsOwner(Guid id, Guid userID)
        {
            return Get(id).UserID == userID ? true : false;
        }
        public void SetProfilePhoto(Guid currentUserId, Guid id)
        {
            if (_context.Images.Any(_ => _.ID == id))
            {
                var user = _context.Users.SingleOrDefault(_ => _.Id == currentUserId);
                user.ProfileImageSrc = Get(id).Src;
                _context.SaveChanges();
            }
        }
        public void SetProfileBackgroundPhoto(Guid currentUserId, Guid id)
        {
            if (_context.Images.Any(_ => _.ID == id))
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
        public void AddAsync(string src, Guid userID)
        {
            _context.Images.AddAsync(new Image()
            {
                Src = src,
                User = _userService.Get(userID),
            });
            _context.SaveChangesAsync();
        }
        public async Task<Image> GetAsync(Guid id)
        {
            return await _context.Images
                .Include(_ => _.Likes)
                .SingleOrDefaultAsync(_ => _.ID == id);
        }
        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await _context.Images.AnyAsync(_ => _.ID == id);
        }
        public async Task<bool> IsOwnerAsync(Guid id, Guid userID)
        {
            var result = await GetAsync(id);
            return result.UserID == userID ? true : false;
        }
        public async Task SetProfilePhotoAsync(Guid currentUserId, Guid id)
        {
            if (await _context.Images.AnyAsync(_ => _.ID == id))
            {
                var user = await _context.Users.SingleOrDefaultAsync(_ => _.Id == currentUserId);
                var img = await GetAsync(id);
                user.ProfileImageSrc = img.Src;
                await _context.SaveChangesAsync();
            }
        }
        public async Task SetProfileBackgroundPhotoAsync(Guid currentUserId, Guid id)
        {
            if (await _context.Images.AnyAsync(_ => _.ID == id))
            {
                var user = await _context.Users.SingleOrDefaultAsync(_ => _.Id == currentUserId);
                var img = await GetAsync(id);
                user.BackgroundImageSrc = img.Src;
                await _context.SaveChangesAsync();
            }
        }
    }
}
