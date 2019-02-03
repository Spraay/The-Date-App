using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.TheDate.Areas.Identity.Pages.Account.Manage
{
    public class ProfileModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}