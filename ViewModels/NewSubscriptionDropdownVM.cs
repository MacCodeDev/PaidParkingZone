using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NewSubscriptionDropdownVM
    {
        public NewSubscriptionDropdownVM()
        {
            Customers = new List<Customers>();
        }
        public List<Customers> Customers { get; set; }
    }
}
