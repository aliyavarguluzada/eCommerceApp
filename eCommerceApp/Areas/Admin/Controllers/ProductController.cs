﻿using eCommerceApp.Filters;
using Microsoft.AspNetCore.Mvc;


namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("admin")]
    [MyAuth("Admin")]
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}

