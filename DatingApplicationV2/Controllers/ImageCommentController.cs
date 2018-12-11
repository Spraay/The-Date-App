using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Enties;
using Services;

namespace DatingApplicationV2.Controllers
{
    public class ImageCommentController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IImageCommentService _imageCommentService;

        public ImageCommentController(IUserService userService, IImageService imageService, IImageCommentService imageCommentService)
        {
            _userService = userService;
            _imageService = imageService;
            _imageCommentService = imageCommentService;
        }

        // GET: ImageComment/Details/5
        public async Task<IActionResult> Details(Guid id, string returnURL = null)
        {
            var imageComment = await _imageCommentService.GetAsync(id);
            return View(imageComment);
        }

        // GET: ImageComments/Create
        public async Task<IActionResult> Add(Guid id, string returnURL = null)
        {
            var isImgExists = await _imageService.IsExistsAsync(id);
            if (!isImgExists)
                RedirectToAction(nameof(ImageNotExists), new { id, returnURL });
            ViewBag.ReturnURL = returnURL;
            return View(new ImageComment() { CommentedItemID = id, CreatorID = _userService.CurrentUserId });
        }

        // POST: ImageComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,CreatorID,CommentedItemID,Content")] ImageComment imageComment, string returnURL = null)
        {
            var img = await _imageService.GetAsync(imageComment.CommentedItemID);
            if (ModelState.IsValid)
            {
                await _imageCommentService.AddCommentAsync(imageComment.ID, _userService.CurrentUserId, imageComment.Content);
                return RedirectToAction(nameof(ImageController) ,nameof(ImageController.UserImages), new { userID = img.UserID });
            }
            ViewData["CommentedItemID"] = img.ID;
            ViewData["CreatorID"] = _userService.CurrentUserId;
            return View(imageComment);
        }

        // GET: ImageComments/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var imageComment = await _imageCommentService.GetAsync(id);
            ViewData["CommentedItemID"] = imageComment.CommentedItemID;
            ViewData["CreatorID"] = imageComment.CreatorID;
            return View(imageComment);
        }

        public IActionResult ImageNotExists(Guid id, string returnURL = null)
        {
            ViewData["ImageID"]= id;
            ViewBag.ReturnURL = returnURL;
            return View();
        }

        //    // POST: ImageComments/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatorID,CommentedItemID,Content")] ImageComment imageComment)
        //    {
        //        if (id != imageComment.CreatorID)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            _imageCommentService.EditComment();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CommentedItemID"] = new SelectList(_context.Images, "ID", "ID", imageComment.CommentedItemID);
        //        ViewData["CreatorID"] = new SelectList(_context.Users, "Id", "Id", imageComment.CreatorID);
        //        return View(imageComment);
        //    }

        //    // GET: ImageComments/Delete/5
        //    public async Task<IActionResult> Delete(Guid? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var imageComment = await _context.ImagesComments
        //            .Include(i => i.CommentedItem)
        //            .Include(i => i.Creator)
        //            .FirstOrDefaultAsync(m => m.CreatorID == id);
        //        if (imageComment == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(imageComment);
        //    }

        //    // POST: ImageComments/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(Guid id)
        //    {
        //        var imageComment = await _context.ImagesComments.FindAsync(id);
        //        _context.ImagesComments.Remove(imageComment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool ImageCommentExists(Guid id)
        //    {
        //        return _context.ImagesComments.Any(e => e.CreatorID == id);
        //    }
    }
}
