using Microsoft.AspNetCore.Mvc;
using CoreAppFood.Repositories;
using CoreAppFood.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System;

namespace CoreAppFood.Controllers
{
    //[AllowAnonymous]
    public class FoodController : Controller
    {
        private FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.getTList("Category").ToPagedList(page,3 ));
        }

        [HttpGet]
        public IActionResult FoodAdd() 
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();

            ViewBag.V1 = values;
            return View(); 
        }

        [HttpPost]
        public IActionResult FoodAdd(Food food)
        {
            //Food f = new Food();
            //if(param.ImageUrl != null)
            //{
            //    var extension = Path.GetExtension(param.ImageUrl.FileName);
            //    var newImageName = Guid.NewGuid() + extension;
            //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/",newImageName);
            //    var stream = new FileStream(location, FileMode.Create);
            //    param.ImageUrl.CopyTo(stream);
            //    f.ImageUrl = newImageName;
            //}

            //f.Name = param.Name;
            //f.Price = param.Price;
            //f.Stock = param.Stock;
            //f.CategoryId = param.CategoryId;
            //f.Desc = param.Desc;

            foodRepository.TAdd(food);
            return RedirectToAction("Index"); 
        }

        public IActionResult FoodDelete(int id)
        {
            foodRepository.TDelete(new Food { FoodId = id});
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var abc = foodRepository.TGet(id);


            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.V1 = values;


            Food food = new Food();
            food.FoodId = id;
            food.CategoryId = abc.CategoryId;
            food.Name = abc.Name;
            food.Stock = abc.Stock;
            food.Price = abc.Price;
            food.Desc = abc.Desc;
            food.ImageUrl = abc.ImageUrl;

            return View(food);
        }


        public IActionResult FoodUpdate(Food food)
        {
            var abc = foodRepository.TGet(food.FoodId);
            abc.CategoryId = food.CategoryId;
            abc.Name = food.Name;
            abc.Stock = food.Stock;
            abc.Price = food.Price;
            abc.Desc = food.Desc;
            abc.ImageUrl = food.ImageUrl;

            foodRepository.TUpdate(abc);
            return RedirectToAction("Index");
        }
    }
}
