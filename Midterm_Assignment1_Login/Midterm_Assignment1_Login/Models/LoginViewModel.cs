using System.ComponentModel.DataAnnotations;

namespace Midterm_Assignment1_Login.Models
{
    public class LoginViewModel
    {
            
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}


