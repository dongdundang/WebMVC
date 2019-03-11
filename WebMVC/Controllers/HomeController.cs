using DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
            //return View();
        }

        [HttpGet]
        public async Task<string> AddUser()
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin"
            };
            ApplicationUserStore userStore = new ApplicationUserStore(new ApplicationDbContext());
            ApplicationUserManager userManager = new ApplicationUserManager(userStore);
            var result = await userManager.CreateAsync(user, "admin");
            if (!result.Succeeded)
            {
                return result.Errors.First();
            }
            return "Added";
        }
    }
}