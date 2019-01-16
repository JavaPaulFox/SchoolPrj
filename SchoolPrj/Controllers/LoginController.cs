using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SchoolPrj.Models;
using SchoolPrj.ViewModel;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolPrj.Controllers
{
    public class LoginController : Controller
    {
        private IOwinContext OwinContext
        {
            get
            {
                return HttpContext.GetOwinContext();
            }
        }
        private UserDatabaseManager UserDatabaseManager
        {
            get
            {
                return OwinContext.Get<UserDatabaseManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public LoginController()
        {
            
        }

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
        public async Task<ActionResult> SignUp(LoginViewModel user)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser() { UserName = user.Email, Address = user.Address, City = user.City, Zip = user.Zip };
                var result = await UserDatabaseManager.CreateAsync(applicationUser, user.Password);
                if(result.Succeeded)
                {
                    return Redirect("/home");
                }
                else
                {
                    return Redirect("/login/signup");
                }
            }
            else
            {
                return Redirect("/login/signup");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginViewModel user)
        {
            ApplicationUser appUser = await UserDatabaseManager.FindAsync(user.Username, user.Password);
            if(appUser != null)
            {
                ClaimsIdentity claim = await UserDatabaseManager.CreateIdentityAsync(appUser,
                                    DefaultAuthenticationTypes.ApplicationCookie);
                AuthenticationManager.SignOut();
                OwinContext.Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, claim);
                return Redirect("/home");
            }
            else
            {
                return Redirect("/login");
            }
        }
    }
}