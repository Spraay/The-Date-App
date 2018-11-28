using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DatingApplicationV2.Controllers
{
    [Authorize(Roles = "User,Admin,Moderator")]
    public class ExploreController : Controller
    {

        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExploreController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetListAsync();

            return View(userList.Where(_=>_.Id!= _userService.CurrentUserId));
        }
    }
}