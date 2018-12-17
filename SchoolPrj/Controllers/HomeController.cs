using Microsoft.AspNet.Identity.Owin;
using SchoolPrj.Models;
using System.Collections.Generic;
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
            List<string> list = new List<string>();
            list.Sort();
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