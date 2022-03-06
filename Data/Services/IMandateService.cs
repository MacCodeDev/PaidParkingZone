using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public interface IMandateService
    {
        Task<IEnumerable<Mandate>> GetAllAsync();

        Task<Mandate> GetByIdAsync(int id);

        Task AddAsync(Mandate mandate);

        Task<Mandate> UpdateAsync(int id, Mandate newMandate);

        Task DeleteAsync(int id);
    }
}
