using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Pełna nazwa")]
        [Required(ErrorMessage = "Pełna nazwa jest wymagana")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email jest wymagany")]
        public string EmailAddress { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [RegularExpression(@"(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$&_/\*]).{6,18}", ErrorMessage = "Twoje hasło wymaga minimum 6 znaków, 1 dużej litery,1 małej litery, 1 cyfry oraz znaku specjalnego")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Potwierdź hasło")]
        [Required(ErrorMessage = "Potwierdzenie hasła jest wymagane")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]
        public string ConfirmPassword { get; set; }
    }
}
