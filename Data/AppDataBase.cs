using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Data
{
    public class AppDataBase:IdentityDbContext<AppUser>
    {
        public AppDataBase(DbContextOptions<AppDataBase> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Mandate> Mandaty { get; set; }
        public DbSet<Subscription> Abonamenty { get; set; }
        public DbSet<Customers> Klienci { get; set; }

    }
}
