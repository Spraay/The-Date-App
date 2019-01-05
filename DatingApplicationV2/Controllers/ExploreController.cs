using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Service.Abstract;
using App.Model.Entities;
using App.Repository.Abstract;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ExploreController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public ExploreController(IUserService userService, IUserRepository userRepository, UserManager<User> userManager)
        {
            _userService = userService;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userList = await _userRepository.GetAllAsync();

            return View(userList.Where(_=>_.Id!= _userService.CurrentUserId));
        }
    }
}