using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.ViewModels.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email bos qala bilmez")]
        [EmailAddress(ErrorMessage ="Email duzgun deyil")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Sifre bos qala bilmez")]
        public string Password { get; set; }
    }
}
