using CoreAppFood.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAppFood.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        Context context = new Context();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var adminData = context.Admins.FirstOrDefault(x => x.AdminName == admin.AdminName 
                                        && x.AdminPassword == admin.AdminPassword);

            if (adminData != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.AdminName)
                };

                var userIdentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index","Default");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
