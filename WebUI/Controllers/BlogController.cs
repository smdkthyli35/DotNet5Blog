using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService _blogService;
        ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
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

        public IActionResult BlogListByWriter()
        {
            var values = _blogService.GetListWithCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryValues = (from i in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = i.CategoryName,
                                                       Value = i.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;


            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            BlogValidator writerValidator = new BlogValidator();
            ValidationResult validationResult = writerValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogService.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


    }
}
