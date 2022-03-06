using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly AppDataBase _context;
        public SubscriptionService(AppDataBase context)
        {
            _context = context;
        }
        public async Task AddAsync(Subscription subscription)
        {
            await _context.Abonamenty.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Abonamenty
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(n => n.SubscriptionId == id);
            _context.Abonamenty.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            var result = await _context.Abonamenty.ToListAsync();
            return result;
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
                
            var result = await _context.Abonamenty
                .Include(c => c.Customers)
                .FirstOrDefaultAsync(n => n.SubscriptionId == id);
            return result;
        }

        public async Task<NewSubscriptionDropdownVM> GetNewSubscriptionDropdownValues()
        {
            var response = new NewSubscriptionDropdownVM();
            response.Customers = await _context.Klienci.OrderBy(n => n.IdNumber).ToListAsync();
            return response;
        }

        public async Task<Subscription> UpdateAsync(int id, Subscription newSubscription)
        {
            _context.Update(newSubscription);
            await _context.SaveChangesAsync();
            return newSubscription;
        }
    }
}
