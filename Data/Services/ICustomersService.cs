using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customers>> GetAllAsync();

        Task<Customers> GetByIdAsync(int id);

        Task AddAsync(Customers customers);

        Task<Customers> UpdateAsync(int id, Customers newCustomers);

        Task DeleteAsync(int id);
    }
}
