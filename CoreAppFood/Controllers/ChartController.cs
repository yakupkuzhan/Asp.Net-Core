using CoreAppFood.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CoreAppFood.Data;
using System.Linq;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace CoreAppFood.Controllers
{
    //[AllowAnonymous]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());
        }

        public IActionResult Index2()
        {
            return View();
        }

        private List<ChartClass> ProductList()
        {
            List<ChartClass> list = new List<ChartClass>();

            list.Add(new ChartClass 
            {
                productName = "Computer",
                stock = 150
                
            });
            list.Add(new ChartClass
            {
                productName = "LCD",
                stock = 75
            });
            list.Add(new ChartClass
            {
                productName = "USB Disk",
                stock = 220
            });

            return list;
        }

        public IActionResult Index3() { return View(); }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        private List<Class> FoodList()
        {
            List<Class> classes = new List<Class>();

            using (var context = new Context())
            {
                classes = context.Foods.Select(x => new Class
                {
                    foodName = x.Name,
                    stock = x.Stock,
                }).ToList();
            }

            return classes;
        }


        public IActionResult Statistics()
        {
            Context context = new Context();
            var value1 = context.Foods.Count();
            ViewBag.Value1 = value1;

            var value2 = context.Categories.Count();
            ViewBag.Value2 = value2;



            var value3 = context.Foods.Where(x => x.CategoryId ==
                                                context.Categories.Where(x => x.CategoryName == "Fruits").Select(x => x.CategoryId).FirstOrDefault()
                                       ).Count();
            ViewBag.Value3 = value3;




            var value4 = context.Foods.Where(x => x.CategoryId ==
                                                context.Categories.Where(x => x.CategoryName == "Vegetables").Select(x => x.CategoryId).FirstOrDefault()
                                       ).Count();
            ViewBag.Value4 = value4;

            


            var value5 = context.Foods.Where(x => x.CategoryId ==
                                                context.Categories.Where(x => x.CategoryName == "Grains").Select(x => x.CategoryId).FirstOrDefault()
                                       ).Count();
            ViewBag.Value5 = value5;



            var value6 = context.Foods.Sum(x => x.Stock);
            ViewBag.Value6 = value6;


            var value7 = context.Foods.OrderByDescending(x => x.Stock).Select(x => x.Name).FirstOrDefault();
            ViewBag.Value7 = value7;

            //context.Foods.OrderBy(x => x.Stock).Select(x => x.Name).FirstOrDefault(); -- Alttaki işlemin farklı yolu
            var value8 = context.Foods.OrderByDescending(x => x.Stock).Select(x => x.Name).LastOrDefault();
            ViewBag.Value8 = value8;    


            var value9 = context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.Value9 = value9;


            var value10 = context.Foods.Where(x => x.CategoryId == 1).Sum(x => x.Stock);
            ViewBag.Value10 = value10;

            var value11 = context.Foods.Where(x => x.CategoryId == 2).Sum(x => x.Stock);
            ViewBag.Value11 = value11;

            var value12 = context.Foods.OrderByDescending(x => x.Price).Select(x => x.Name).FirstOrDefault();
            ViewBag.Value12 = value12;


            return View();
        }

    }
}
