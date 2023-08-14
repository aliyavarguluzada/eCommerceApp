using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.ViewModels.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Ad bos qala bilmez")]
        [MaxLength(15,ErrorMessage ="Ad 15 den kicik olmalidi")]
        [MinLength(3,ErrorMessage ="Ad 3 den kicik ola bilmez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad bos qala bilmez")]
        [MaxLength(15, ErrorMessage = "Ad 15 den kicik olmalidi")]
        [MinLength(3, ErrorMessage = "Ad 3 den kicik ola bilmez")]

        public string Surname { get; set; }

        [Required(ErrorMessage = "Email bos qala bilmez")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifre bos qala bilmez")]

        public string Password { get; set; }

        [Required(ErrorMessage ="Tekrar sifre duzgun deyil")]
        [Compare("Password",ErrorMessage="Tekrar sifre duzgun deyil")]

        public string ConfirmPassword { get; set; }

    }
}
