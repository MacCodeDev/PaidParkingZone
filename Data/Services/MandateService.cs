using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public class MandateService : IMandateService
    {
        private readonly AppDataBase _context;
        public MandateService(AppDataBase context)
        {
            _context = context;
        }
        public async Task AddAsync(Mandate mandate)
        {
            await _context.Mandaty.AddAsync(mandate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Mandaty.FirstOrDefaultAsync(n => n.MandateId == id);
            _context.Mandaty.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mandate>> GetAllAsync()
        {
            var result = await _context.Mandaty.ToListAsync();
            return result;
        }

        public async Task<Mandate> GetByIdAsync(int id)
        {
            var result = await _context.Mandaty.FirstOrDefaultAsync(n => n.MandateId == id);
            return result;
        }

        public async Task<Mandate> UpdateAsync(int id, Mandate newMandate)
        {
            _context.Update(newMandate);
            await _context.SaveChangesAsync();
            return newMandate;
        }
    }
}
