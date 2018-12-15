using Microsoft.AspNet.Identity.Owin;
using SchoolPrj.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            ApplicationUser user = new ApplicationUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult SignUp(ApplicationUser user)
        {
            var hmac = new HMACSHA256();
            byte[] bytes = Encoding.ASCII.GetBytes(user.PasswordHash);
            var passHash = Encoding.ASCII.GetString(hmac.ComputeHash(bytes));
            user.PasswordHash = passHash;
            var owin = HttpContext.GetOwinContext();
            var manager = owin.Get<DatabaseManager>();
            manager.CreateAsync(user);
            return Redirect("/home");
        }
    }
}