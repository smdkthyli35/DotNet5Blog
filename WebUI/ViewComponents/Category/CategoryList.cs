using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        ICategoryService _categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetAll();
            return View(values);
        }
    }
}
