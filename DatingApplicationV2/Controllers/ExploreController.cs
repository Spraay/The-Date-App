using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Model;
using App.Service.Abstract;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ExploreController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public ExploreController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAllAsync();

            return View(userList.Where(_=>_.Id!= _userService.CurrentUserId));
        }
    }
}