
using DAO.Data;
using Enties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ImageService : IImageService
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

        public void AddAsync(string src, Guid userID)
        {
            _context.Images.AddAsync(new Image()
            {
                Src = src,
                User = _userService.Get(userID),
            });
            _context.SaveChangesAsync();
        }

        public void Delete(string src)
        {
            var imgToRemove = _context.Images.SingleOrDefault(_ => _.Src == src);
            _context.Images.Remove(imgToRemove);
            _context.SaveChanges();
        }

        public Image Get(Guid id)
        {
            return _context.Images.SingleOrDefault(_ => _.ID == id);
        }

        public async Task<Image> GetAsync(Guid id)
        {
            return await _context.Images.SingleOrDefaultAsync(_ => _.ID == id);
        }

        public List<Image> GetUserImages(Guid userID)
        {
            return _context.Images.Where(_ => _.UserID == userID).ToList();
        }

        public bool IsExists(Guid id)
        {
            return _context.Images.Any(_ => _.ID == id);
        }

        public async Task<bool> IsExistsAsync(Guid id)
        {
            return await _context.Images.AnyAsync(_ => _.ID == id);
        }

        public bool IsOwner(Guid id, Guid userID)
        {
            return Get(id).UserID == userID ? true : false;
        }

        public async Task<bool> IsOwnerAsync(Guid id, Guid userID)
        {
            var result = await GetAsync(id);
            return result.UserID == userID ? true : false;
        }
    }
}
