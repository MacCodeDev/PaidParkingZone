using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription> GetByIdAsync(int id);
        Task AddAsync(Subscription subscription);
        Task<Subscription> UpdateAsync(int id, Subscription newSubscription);
        Task DeleteAsync(int id);
        Task<NewSubscriptionDropdownVM> GetNewSubscriptionDropdownValues();
    }
}
