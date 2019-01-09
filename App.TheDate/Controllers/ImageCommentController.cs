using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Service.Abstract;
using App.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using App.Repository.Abstract;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ImageCommentController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageRepository _imageRepository;
        private readonly IImageCommentService _imageCommentService;

        public ImageCommentController(IUserService userService, IImageRepository imageRepository, IImageCommentService imageCommentService)
        {
            _userService = userService;
            _imageRepository = imageRepository;
            _imageCommentService = imageCommentService;
        }

        public async Task<IActionResult> Details(Guid id, string returnURL = null)
        {
            return View(await _imageCommentService.GetAsync(id));
        }
        public async Task<IActionResult> Add(Guid id, string returnURL = null)
        {
           
            if (!await _imageRepository.IsExistsAsync(id))
                RedirectToAction(nameof(ImageNotExists), new { id, returnURL });
            ViewBag.ReturnURL = returnURL;
            return View(new ImageComment() { CommentedItemId = id, CreatorId = _userService.CurrentUserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,CreatorID,CommentedItemID,Content")] ImageComment imageComment, string returnURL = null)
        {
            var img = await _imageRepository.GetSingleAsync(imageComment.CommentedItemId);
            if (ModelState.IsValid)
            {
                await _imageCommentService.CreateAsync(imageComment.Id, _userService.CurrentUserId, imageComment.Content);
                return RedirectToAction(nameof(ImageController) ,nameof(ImageController.UserImages), new { userID = img.UserId });
            }
            ViewData["CommentedItemID"] = img.Id;
            ViewData["CreatorID"] = _userService.CurrentUserId;
            return View(imageComment);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var imageComment = await _imageCommentService.GetAsync(id);
            ViewData["CommentedItemID"] = imageComment.CommentedItemId;
            ViewData["CreatorID"] = imageComment.CreatorId;
            return View(imageComment);
        }

        public IActionResult ImageNotExists(Guid id, string returnURL = null)
        {
            ViewData["ImageID"]= id;
            ViewBag.ReturnURL = returnURL;
            return View();
        }
    }
}
