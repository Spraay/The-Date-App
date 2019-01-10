using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Model.Error;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ItemNotFound(ItemError error, string returnURL = null)
        {
            ViewBag.ReturnURL = returnURL;
            return View(error);
        }
    }
}