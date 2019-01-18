using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int AddToCart(Guid id)
        {
            Session["cart"] += id.ToString()+",";
            string[] goodsInCart = Session["cart"].ToString().Split(',');
            return goodsInCart.Length-1;
        }
    }
}