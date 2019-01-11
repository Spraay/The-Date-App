using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using App.Model.Error;
using Microsoft.AspNetCore.Authorization;

namespace App.TheDate.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ImageCommentController : Controller
    {
        private readonly IImageCommentRepository _imageCommentRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IUserService _userService;

        public ImageCommentController(IImageCommentRepository imageCommentRepository, IImageRepository imageRepository, IUserService userService)
        {
            _imageCommentRepository = imageCommentRepository;
            _imageRepository = imageRepository;
            _userService = userService;
        }

        // GET: ImageComments/5
        public async Task<IActionResult> List(Guid? id, string returnURL = null)
        {
            if (!id.HasValue)
                return NotFound();
            var query = _imageCommentRepository
                .FindByAsync(_ => _.CommentedItemId == (id.Value),
                    _ => _.CommentedItem,
                    _ => _.Creator
                );
            ViewBag.Image = await _imageRepository
                .GetSingleAsync(_=>_.Id == id.Value,
                    _=>_.Likes
                );
            ViewBag.CurrentUserId = _userService.CurrentUserId;
            ViewBag.ReturnURL = returnURL;
            return View(await query);
        }

        public IActionResult Create(Guid? id, string returnURL = null)
        {
            if(!id.HasValue)
                return NotFound();
            ViewBag.ReturnURL = returnURL;
            var newImage = new ImageComment()
            {
                CreatorId = _userService.CurrentUserId,
                CommentedItemId = id.Value
            };
            return View(newImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CommentedItemId,CreatorId,Content")] ImageComment imageComment)
        {
            if (ModelState.IsValid)
            {
                _imageCommentRepository.Add(new ImageComment() { CommentedItemId = imageComment.CommentedItemId, CreatorId = _userService.CurrentUserId, Content = imageComment.Content });
                await _imageCommentRepository.CommitAsync();
                return RedirectToAction(nameof(List), new { id = imageComment.CommentedItemId });
            }
            return View(imageComment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateByText(Guid imgId, string content, ImageComment imageComment = null)
        {
            if (imgId != Guid.Empty && content!=string.Empty)
            {
                _imageCommentRepository.Add(new ImageComment() { CommentedItemId = imgId, CreatorId = _userService.CurrentUserId, Content = content });
                await _imageCommentRepository.CommitAsync();
                return RedirectToAction(nameof(List), new { id = imgId });
            }
            ModelState.AddModelError("AddError", "Image Id or comment content is empty values");
            return RedirectToAction(nameof(Create), new { id = imgId });
        }

        // GET: ImageComments/Edit/5
        public async Task<IActionResult> Edit(Guid? id, string returnURL = null)
        {
            if (!id.HasValue)
                return NotFound();
            var imageComment = await _imageCommentRepository.GetSingleAsync(id.Value);
            if (imageComment == null)
                return NotFound();
            ViewBag.ReturnURL = returnURL;
            return View(imageComment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatorId,CommentedItemId,Content")] ImageComment imageComment)
        {
            if (id != imageComment.CreatorId)
                return NotFound();
            if (ModelState.IsValid)
            {
                _imageCommentRepository.Update(imageComment);
                await _imageCommentRepository.CommitAsync();
                return RedirectToAction(nameof(List), new { id });
            }
            return View(imageComment);
        }

        public async Task<IActionResult> Delete(Guid? id, string returnURL = null)
        {
            if (!id.HasValue)
                return NotFound();
            var imageComment = await _imageCommentRepository
                .GetSingleAsync(_ => _.Id == (id.Value),
                    _ => _.CommentedItem,
                    _ => _.Creator
                );
            if (imageComment == null)
            {
                var error = new ItemError() { Id = id.Value, Type = typeof(ImageComment) };
                return RedirectToAction("ItemNotFound", "Error", new { error, returnURL });
            }
           
            ViewBag.ReturnURL = returnURL;
            return View(imageComment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _imageCommentRepository.DeleteWhere(_ => _.Id == id);
            await _imageCommentRepository.CommitAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
