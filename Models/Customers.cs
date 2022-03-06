using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Customers
    {
        [Key]
        [Display(Name = "Numer klienta")]
        public int CustomersId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [Display(Name = "Pesel Klienta")]
        [Required(ErrorMessage = "Pesel jest wymagany")]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "Nie wpisałeś numeru pesel albo podałeś za mało lub za dużo cyfr")]
        public string IdNumber { get; set; }

        [Display(Name = "Data dodania klienta")]
        [Required(ErrorMessage = "Data dodania jest wymagana")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Display(Name = "Numer wniosku")]
        [Required(ErrorMessage = "Numer wniosku jest wymagany")]
        [RegularExpression(@"^\(?[0-9]*$", ErrorMessage ="Proszę użyć tylko liczb")]
        public string ApplicationNumber { get; set; }


        //Relacje
        public List<Subscription> Subscriptions { get; set; }
    }
}
