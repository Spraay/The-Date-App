using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Infrastructure.DAO.Data;
using Core.Models.Entities;

namespace Core.Services
{
    public partial class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public ImageService(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public string[] AllowedExtensions { get; } = {
            ".jpg",
            ".img",
            ".jpeg",
            ".png",
            ".gif"
        };

        public string GetAllowedExtensionsMsg()
        {
            string errorMsg = "Only this image extensions are allowed: ";
            foreach (var e in AllowedExtensions)
            {
                if (e != AllowedExtensions[AllowedExtensions.Count() - 1])
                    errorMsg += e + ", ";
                else
                    errorMsg += e;
            }
            return errorMsg;
        }

        public void DeleteFile(string src)
        {
            var path = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages", src);
            if (File.Exists(path))
                File.Delete(path);
        }

        public async Task<Image> CreateImageAsync(IFormFile file, Guid userId)
        {
            var uploads = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages");
            var fileName = userId + Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return new Image() { Src = fileName, UserId=userId };
        }
    }
}
