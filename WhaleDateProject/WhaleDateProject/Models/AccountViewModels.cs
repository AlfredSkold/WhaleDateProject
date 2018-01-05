using Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhaleDateProject.Models
{

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email måste fyllas i")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lösenord måste fyllas i")]
        [StringLength(100, ErrorMessage = "{0} Måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte")]
        [Display(Name = "Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Förnamn måste fyllas i")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Efternamn måste fyllas i")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Typ av val måste fyllas i")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Ålder måste fyllas i")]
        [Range(1, 1000, ErrorMessage = "Ålder kan bara vara siffror")]
        public string Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string InterestedIn { get; set; }


    }

    
}
