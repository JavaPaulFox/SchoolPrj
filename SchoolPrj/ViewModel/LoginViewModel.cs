using System.ComponentModel.DataAnnotations;

namespace SchoolPrj.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}