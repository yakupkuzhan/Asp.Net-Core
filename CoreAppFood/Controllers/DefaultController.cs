using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppFood.Controllers
{
    //[AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
