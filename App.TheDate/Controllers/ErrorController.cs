using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplicationV2.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ItemNotFound(string exception = null)
        {
            ViewBag.Exception = exception;
            return View();
        }
    }
}