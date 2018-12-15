using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolPrj.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}