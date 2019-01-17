using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SchoolPrj.Models;
using SchoolPrj.ViewModel;
using System;
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

        [HttpPost]
        public ActionResult Add(GoodViewModel good)
        {
            GoodsTypes type = OwinContext.Get<DatabaseContext>().GoodsTypes.FirstOrDefault(x => x.Id == new Guid(good.GoodsTypes));
            OwinContext.Get<DatabaseContext>().Goods.Add(new Goods()
            {
                Id = Guid.NewGuid(),
                Title = good.Title,
                Description = good.Description,
                Price = good.Price,
                GoodsTypes = type
            });
            OwinContext.Get<DatabaseContext>().SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public JsonResult GetGoodsTypes()
        {
            List<GoodsTypes> result = OwinContext.Get<DatabaseContext>().GoodsTypes.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}