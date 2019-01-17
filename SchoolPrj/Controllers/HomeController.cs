using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using SchoolPrj.Models;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace SchoolPrj.Controllers
{
    public class HomeController : Controller
    {
        private IOwinContext OwinContext
        {
            get
            {
                return HttpContext.GetOwinContext();
            }
        }
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            List<Goods> goods= OwinContext.Get<DatabaseContext>().Goods.ToList();
            return View(goods);
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