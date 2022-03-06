using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Mandate
    {
        [Key]
        [Display(Name = "Numer Mandatu")]
        public int MandateId { get; set; }

        [Display(Name = "Numer Rejestracyjny")]
        [Required(ErrorMessage ="Numer rejestracyjny jest wymagany")]
        [StringLength(15,MinimumLength = 4, ErrorMessage = "Numer rejestracyjny musi mieć minimum 4 znaki")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        [RegularExpression(@"^\(?[0-9]*$", ErrorMessage = "Proszę użyć tylko liczb")]
        public string Price { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Ulica jest wymagana")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numer rejestracyjny musi mieć minimum 4 znaki")]
        public string Street { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Data jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Opłacony")]
        public bool Paid { get; set; }

        [Display(Name = "Zdjęcie")]
        public string PictureUrl { get; set; }
    }
}
