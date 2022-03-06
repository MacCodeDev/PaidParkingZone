using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class LoginVM
    {   
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email jest wymagany")]
        public string EmailAddress { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
