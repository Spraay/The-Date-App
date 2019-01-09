using App.Model.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace App.Service.Abstract
{
    public partial interface IImageService
    {
        string[] AllowedExtensions { get; }

        string GetAllowedExtensionsMsg();

        void DeleteFile(string src);

        Task <Image>CreateImageAsync(IFormFile file, Guid userId);
    }
}