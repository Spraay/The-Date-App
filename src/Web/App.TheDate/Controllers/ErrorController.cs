using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Error;
using Microsoft.AspNetCore.Mvc;

namespace Core.TheDate.Controllers
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