using Projekt.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Subscription
    {
        [Key]
        [Display(Name = "Numer Abonamentu")]
        public int SubscriptionId { get; set; }

        [Display(Name = "Numer Rejestracyjny")]
        [Required(ErrorMessage ="Numer rejestracyjny jest wymagany")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Numer rejestracyjny wymaga minimum 4 znaki")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Ulica jest wymagana")]
        public string Street { get; set; }

        [Display(Name = "Data rozpoczęcia")]
        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Data zakończenia")]
        [Required(ErrorMessage = "Data zakończenia jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get { return StartDate.AddDays(30); } set{}}

        [Display(Name = "Rodzaj Abonamentu")]
        [Required(ErrorMessage = "Rodzaj abonamentu jest wymagany")]
        [EnumDataType(typeof(SubscriptionVariant))]
        public SubscriptionVariant SubscriptionVariant { get; set; }

        [Display(Name = "Cena Abonamentu")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        [RegularExpression(@"^\(?[0-9]*$", ErrorMessage = "Proszę użyć tylko liczb")]
        public string Paid { get; set; }

        [Display(Name = "Aktywny")]
        public bool Active { get; set; }

        //Relacje
        [Display(Name = "Pesel klienta")]
        public int CustomersId { get; set; }
        [ForeignKey("CustomersId")]
        public Customers Customers { get; set; }
    }
}
