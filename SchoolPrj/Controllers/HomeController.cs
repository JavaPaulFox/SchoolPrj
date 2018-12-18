using System.Collections.Generic;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public ActionResult Index()
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