using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Enties;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User")]
    public class ImageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _appEnvironment;

        private readonly string[] allowedExtensions = {
            ".jpg",
            ".img",
            ".jpeg",
            ".png",
            ".gif"
        };

        public string GetAllowedExtensionsMsg()
        {
            string errorMsg = "Only this image extensions are allowed: ";
            foreach (var e in allowedExtensions)
            {
                if (e != allowedExtensions[allowedExtensions.Count()-1])
                    errorMsg += e + ", ";
                else
                    errorMsg += e;
            }
            return errorMsg;
        }

        public ImageController(IUserService userService, IImageService imageService, UserManager<User> userManager, IHostingEnvironment appEnvironment)
        {
            _userService = userService;
            _imageService = imageService;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }

        public ActionResult Index()
        {
            return RedirectToAction(nameof(UserImages), new { id = _userManager.GetUserId(User)});
           
        }
        // GET: Image
        // user gallery
        public ActionResult UserImages(Guid id)
        {
            return View(_imageService.GetList(id));
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            ViewBag.AllowedExtensionsMsg = GetAllowedExtensionsMsg();
            return View();
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
                    if (!allowedExtensions.Contains(Path.GetExtension(file.FileName)))
                    {
                        ModelState.AddModelError(string.Empty, GetAllowedExtensionsMsg());
                        return RedirectToAction(nameof(Create));
                    }

                    Guid.TryParse(_userManager.GetUserId(User), out Guid currentUser);
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages");
                    var fileName = currentUser + Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        _imageService.Create(fileName, currentUser, image.Title, image.Description);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        // GET: Image/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_imageService.IsOwner(id, Guid.Parse(_userManager.GetUserId(User))))
                return View(_imageService.Get(id));
            ModelState.AddModelError(string.Empty, "You are not owner of photo with id = "+id+"");
            return RedirectToAction(nameof(Index));

        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            
            var img = _imageService.Get(id);
            var path = Path.Combine(_appEnvironment.WebRootPath, "images\\userimages", img.Src);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _imageService.Delete(img.Src);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetProfilePhoto(Guid id, string returnURL = null)
        {
            _imageService.SetProfilePhoto(_userService.CurrentUserId, id);
            return View(_imageService.Get(id));
        }
        public IActionResult SetProfileBackgroundPhoto(Guid id, string returnURL = null)
        {
            _imageService.SetProfileBackgroundPhoto(_userService.CurrentUserId, id);
            return View(_imageService.Get(id));
        }
    }
}