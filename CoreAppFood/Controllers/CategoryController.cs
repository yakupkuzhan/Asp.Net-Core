using Microsoft.AspNetCore.Mvc;
using CoreAppFood.Repositories;
using CoreAppFood.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAppFood.Controllers
{
    //[AllowAnonymous]
    public class CategoryController : Controller
    {
        private CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                return View(categoryRepository.Lst(x => x.CategoryName == param));
            }
            return View(categoryRepository.TList());
        }

        [HttpGet]
        public IActionResult CategoryAdd() { return View(); }

        [HttpPost]
        public IActionResult CategoryAdd(Category category) 
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
        }

        public IActionResult GetCategory(int id)
        {
            var abc = categoryRepository.TGet(id);

            Category category = new Category();

            category.CategoryName = abc.CategoryName;
            category.CategoryId = abc.CategoryId;
            category.CategoryDesc = abc.CategoryDesc;

            return View(abc);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category param)
        {
            var abc = categoryRepository.TGet(param.CategoryId);

            abc.CategoryName = param.CategoryName;
            abc.CategoryId = param.CategoryId;
            abc.CategoryDesc = param.CategoryDesc;
            abc.IsDeleted = param.IsDeleted;

            categoryRepository.TUpdate(abc);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryStatus(int id)
        {
            var abc = categoryRepository.TGet(id);
            abc.IsDeleted = false;
            categoryRepository.TUpdate(abc);

            return RedirectToAction("Index");
        }
    }
}
