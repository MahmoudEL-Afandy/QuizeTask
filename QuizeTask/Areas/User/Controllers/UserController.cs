﻿using Microsoft.AspNetCore.Mvc;

namespace QuizeTask.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
