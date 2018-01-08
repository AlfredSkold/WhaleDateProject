using Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhaleDateProject.Models
{

    

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
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email måste fyllas i.")]
        [EmailAddress(ErrorMessage = "Ogiltig email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lösenord måste fyllas i")]
        [StringLength(100, ErrorMessage = "{0} Måste vara minst {2} tecken långt.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$", ErrorMessage = "Lösenordet måste innehålla en liten/stor bokstav och en siffra.")]
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
