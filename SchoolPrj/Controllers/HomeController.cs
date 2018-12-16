using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SchoolPrj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public async Task<ActionResult> Index()
        {
            var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            var result = await roleManager.RoleExistsAsync("Admin");
            if (!result)
            {
                await roleManager.CreateAsync(new ApplicationRole() { Name = "Admin" });
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}