using System;
using Microsoft.AspNetCore.Mvc;
using App.Service.Abstract;

namespace DatingApplicationV2.Controllers
{
    public class ImageLikeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IImageLikeService _imageLikeService;

        public ImageLikeController(IUserService userService, IImageService imageService, IImageLikeService imageLikeService)
        {
            _userService = userService;
            _imageService = imageService;
            _imageLikeService = imageLikeService;
        }

        public ActionResult ToggleLike(Guid id, string returnURL = null)
        {
            _imageLikeService.ToggleImageLike(id, _userService.CurrentUserId);
            ViewBag.isLiked = _imageLikeService.IsImageLiked(id, _userService.CurrentUserId);
            ViewBag.returnURL = returnURL + "?userID=" + _userService.CurrentUserId.ToString();
            return View(_imageService.Get(id));
        }
    }
}