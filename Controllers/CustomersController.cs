using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Data.Services;
using Projekt.Data.Static;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;
        public CustomersController(ICustomersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCustomers = await _service.GetAllAsync();
            return View(allCustomers);
        }


        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Surname,IdNumber,Date,ApplicationNumber")] Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            await _service.AddAsync(customers);
            return RedirectToAction(nameof(Index));
        }


        //Edit
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var customersEdit = await _service.GetByIdAsync(id);
            if (customersEdit == null) return View("NotFound");


            return View(customersEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CustomersId,Name,Surname,IdNumber,Date,ApplicationNumber")] Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return View(customers);
            }
            await _service.UpdateAsync(id, customers);
            return RedirectToAction(nameof(Index));
        }


        //Delete
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var customersDelete = await _service.GetByIdAsync(id);
            if (customersDelete == null) return View("NotFound");


            return View(customersDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customersDelete = await _service.GetByIdAsync(id);
            if (customersDelete == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
