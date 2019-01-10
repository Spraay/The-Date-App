using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using App.Model.Error;
using App.Model.View;

namespace App.TheDate.Controllers
{
    public class ImageCommentController : Controller
    {
        private readonly IImageCommentRepository _imageCommentRepository;
        private readonly IUserService _userService;

        public ImageCommentController(IImageCommentRepository imageCommentRepository, IUserService userService)
        {
            _imageCommentRepository = imageCommentRepository;
            _userService = userService;
        }

        // GET: ImageComments/5
        public async Task<IActionResult> List(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();
            var query = _imageCommentRepository
                .FindByAsync(_ => _.CommentedItemId == (id.Value),
                    _ => _.CommentedItem,
                    _ => _.Creator
                );
            ViewBag.CurrentUserId = _userService.CurrentUserId;
            return View(new BigImageCommentModel() { ImageComments = await query });
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
        public async Task<IActionResult> CreateAsd(Guid imgId, string content)
        {
            if (ModelState.IsValid)
            {
                _imageCommentRepository.Add(new ImageComment() { CommentedItemId = imgId, CreatorId = _userService.CurrentUserId, Content = content });
                await _imageCommentRepository.CommitAsync();
                return RedirectToAction(nameof(List), new { id = imgId });
            }
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
