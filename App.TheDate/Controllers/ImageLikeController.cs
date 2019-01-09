using System;
using Microsoft.AspNetCore.Mvc;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using App.Repository.Abstract;
using System.Threading.Tasks;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ImageLikeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageRepository _imageRepository;
        private readonly IImageLikeService _imageLikeService;

        public ImageLikeController(IUserService userService, IImageRepository imageRepository, IImageLikeService imageLikeService)
        {
            _userService = userService;
            _imageRepository = imageRepository;
            _imageLikeService = imageLikeService;
        }

        public async Task<IActionResult> ToggleLike(Guid id, string returnURL = null)
        {
            await _imageLikeService.ToggleLikeAsync(_userService.CurrentUserId, id);
            ViewBag.isLiked = await _imageLikeService.IsLikedByAsync(id, _userService.CurrentUserId);
            ViewBag.returnURL = returnURL + "?id=" + _userService.CurrentUserId.ToString();
            return View(await _imageRepository.GetSingleAsync(id));
        }
    }
}