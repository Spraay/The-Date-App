using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Model.Entities;
using App.Repository.Abstract;
using App.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ImageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IImageService _imageService;
        private readonly IImageRepository _imageRepository;

        public ImageController(IUserService userService, IUserRepository userRepository, IImageService imageService, IImageRepository imageRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
            _imageService = imageService;
            _imageRepository = imageRepository;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(UserImages), new { id = _userService.CurrentUserId });
        }

        public async Task<IActionResult> UserImages(Guid id)
        {
            var query = _imageRepository
                .FindByAsync(
                    _=>_.UserId==id,
                    _ => _.Likes,
                    _=>_.Comments,
                    _=>_.User
                );
            ViewBag.User = await _userRepository.GetSingleAsync(id);
            ViewBag.CurrentUserId = _userService.CurrentUserId;
            return View(await query);
        }

        public ActionResult Create()
        {
            ViewBag.AllowedExtensionsMsg = _imageService.GetAllowedExtensionsMsg();
            return View();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (await _imageRepository.IsOwnerAsync(_userService.CurrentUserId, id))
            {
                var image = await _imageRepository.GetSingleAsync(id);
                return View(image);
            }
            return RedirectToAction(nameof(UserImages), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,Description")] Image image)
        {
            var img = await _imageRepository.GetSingleAsync(image.Id);
            if (img!=null && img.UserId == _userService.CurrentUserId)
            {
                img.Description = image.Description;
                img.Title = image.Title;
                _imageRepository.Update(img);
                await _imageRepository.CommitAsync();
            }
            return RedirectToAction(nameof(UserImages), new { id = img.UserId });
        }


        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description")] Image image, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    if (!_imageService.AllowedExtensions.Contains(Path.GetExtension(file.FileName)))
                    {
                        ModelState.AddModelError(string.Empty, _imageService.GetAllowedExtensionsMsg());
                        return RedirectToAction(nameof(Create));
                    }
                    var img = await _imageService.CreateImageAsync(file, _userService.CurrentUserId);
                    img.Title = image.Title;
                    img.Description = image.Description;
                    await _imageRepository.AddAsync(img);
                    await _imageRepository.CommitAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _imageRepository.IsOwnerAsync(_userService.CurrentUserId, id))
                return View(await _imageRepository.GetSingleAsync(id));
            ModelState.AddModelError(string.Empty, "You are not owner of photo with id = "+id+"");
            return RedirectToAction(nameof(Index));
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var img = await _imageRepository.GetSingleAsync(_=>_.Id==id, _=>_.User);
            
            if (img.User.ProfileImageSrc == img.Src )
            {
                img.User.ProfileImageSrc = "NoProfileImage.png";
                _userRepository.Update(img.User);
                await _userRepository.CommitAsync();
            }
            _imageRepository.DeleteWhere(_=>_.Id == id);
            await _imageRepository.CommitAsync();
            _imageService.DeleteFile(img.Src);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SetProfilePhoto(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            var user = await _userRepository.GetSingleAsync(_ => _.Id == _userService.CurrentUserId);
            var img = await _imageRepository.GetSingleAsync(_ => _.Id == id);
            user.ProfileImageSrc = img.Src;
            _userRepository.Update(user);
            await _userRepository.CommitAsync();
            return View(img);
        }

        public async Task<IActionResult> SetProfileBackgroundPhoto(Guid id, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            var user = await _userRepository.GetSingleAsync(_ => _.Id == _userService.CurrentUserId);
            var img = await _imageRepository.GetSingleAsync(_ => _.Id == id);
            user.BackgroundImageSrc = img.Src;
            _userRepository.Update(user);
            await _userRepository.CommitAsync();
            return View(img);
        }
    }
}