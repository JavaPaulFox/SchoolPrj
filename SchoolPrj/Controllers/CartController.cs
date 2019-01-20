using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using SchoolPrj.Models;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using SchoolPrj.ViewModel;
using System.Net.Mail;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace SchoolPrj.Controllers
{
    public class CartController : Controller
    {

        private IOwinContext OwinContext
        {
            get
            {
                return HttpContext.GetOwinContext();
            }
        }
        // GET: Cart
        public ActionResult Index()
        {
            List<string> goodsInCart = Session["cart"]?.ToString()?.Split(',').ToList();
            if(goodsInCart!= null && goodsInCart[goodsInCart.Count-1] == "")
            {
                goodsInCart.RemoveAt(goodsInCart.Count - 1);
                var dbItems = OwinContext.Get<DatabaseContext>().Goods.Include(r => r.GoodsTypes).Where(x => goodsInCart.Contains(x.Id.ToString())).ToList();
                List<CartViewModel> result = new List<CartViewModel>();
                foreach (var i in dbItems)
                {
                    CartViewModel viewModel = new CartViewModel();
                    viewModel.Title = i.Title;
                    viewModel.Price = i.Price;
                    foreach (var y in goodsInCart)
                    {
                        if (y == i.Id.ToString())
                        {
                            viewModel.CountOfItems += 1;
                        }
                    }
                    viewModel.TotalPrice += viewModel.Price * viewModel.CountOfItems;
                    result.Add(viewModel);
                }
                return View(result);
            }
            else
            {
                return View();
            }
            
            
        }

        [HttpPost]
        public int AddToCart(Guid id)
        {
            Session["cart"] += id.ToString()+",";
            string[] goodsInCart = Session["cart"].ToString().Split(',');
            return goodsInCart.Length-1;
        }

        [HttpGet]
        public int GetCountOfItems()
        {
            List<string> goodsInCart = Session["cart"]?.ToString()?.Split(',').ToList();
            if (goodsInCart != null && goodsInCart[goodsInCart.Count - 1] == "")
            {
                goodsInCart.RemoveAt(goodsInCart.Count - 1);
                return goodsInCart.Count;
            }
            else
            {
                return 0;
            }
            
        }

        [HttpPost]
        public bool Order(CartViewModel order)
        {
            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
            smtp.EnableSsl = true;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("p.tamkovich@outlook.com", "Pashtet10157!");



            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            string email = OwinContext.Get<UserDatabaseManager>().GetEmail(User.Identity.GetUserId());
            mail.From = new MailAddress("p.tamkovich@outlook.com");
            mail.Subject = "Your Order";
            mail.To.Add(new MailAddress(email));
            mail.Body = "Hello You order has been sent. Total Price is "+order.TotalPrice;
            smtp.Send(mail);

            return true;
        }
    }
}