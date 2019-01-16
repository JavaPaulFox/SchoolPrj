using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}