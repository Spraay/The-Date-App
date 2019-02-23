using Core.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public partial interface IImageService
    {
        string[] AllowedExtensions { get; }

        string GetAllowedExtensionsMsg();

        void DeleteFile(string src);

        Task <Image>CreateImageAsync(IFormFile file, Guid userId);
    }
}