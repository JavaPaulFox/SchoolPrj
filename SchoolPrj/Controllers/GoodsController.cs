using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SchoolPrj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class GoodsController : Controller
    {
        private IOwinContext OwinContext
        {
            get
            {
                return HttpContext.GetOwinContext();
            }
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public List<string> GetGoodsTypes()
        {
            List<string> result = OwinContext.Get<DatabaseContext>().GoodsTypes.ToList().Select(o => o.Name).ToList();
            return result;
        }
    }
}