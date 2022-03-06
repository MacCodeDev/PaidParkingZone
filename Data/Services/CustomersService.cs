using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly AppDataBase _context;
        public CustomersService(AppDataBase context)
        {
            _context = context;
        }
        public async Task AddAsync(Customers customers)
        {
            await _context.Klienci.AddAsync(customers);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Klienci.FirstOrDefaultAsync(n => n.CustomersId == id);
            _context.Klienci.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            var result = await _context.Klienci.ToListAsync();
            return result;
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            var result = await _context.Klienci.FirstOrDefaultAsync(n => n.CustomersId == id);
            return result;
        }

        public async Task<Customers> UpdateAsync(int id, Customers newCustomers)
        {
            _context.Update(newCustomers);
            await _context.SaveChangesAsync();
            return newCustomers;
        }
    }
}
