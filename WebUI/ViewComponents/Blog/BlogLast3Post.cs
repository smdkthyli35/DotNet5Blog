﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        IBlogService _blogService;

        public BlogLast3Post(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetLast3Blog();
            return View(values);
        }
    }
}

