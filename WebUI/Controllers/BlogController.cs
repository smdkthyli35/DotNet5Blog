using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var result = _blogService.GetBlogListWithCategory();
            return View(result);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = _blogService.GetBlogById(id);
            return View(values);
        }
    }
}
