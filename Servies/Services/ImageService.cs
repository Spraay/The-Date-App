
using DAO.Data;
using Enties;
using System;
using System.Collections.Generic;
using System.Linq;


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

        public List<Image> GetUserImages(Guid userID)
        {
            return _context.Images.Where(_ => _.UserID == userID).ToList();
        }

        public bool IsOwner(Guid id, Guid userID)
        {
            return Get(id).UserID == userID ? true : false;
        }
    }
}
