using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projekt.Data;
using Projekt.Data.Services;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDataBase>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddControllersWithViews();

            //konfiguracja services
            services.AddScoped<IMandateService, MandateService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ICustomersService, CustomersService>();

            //Autoryzacja Identity
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDataBase>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //Autoryzacja 
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //Dane do bazy danych
            AppDataBaseInitializer.SeedUsersAndRolesAsync(app).Wait();

        }
    }
}
