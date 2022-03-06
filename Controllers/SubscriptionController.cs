using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _service;
        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSubscription = await _service
                .GetAllAsync();
            return View(allSubscription);
        }

        //Create
        public async Task<IActionResult> Create()
        {
            var subscriptionDropdownsData = await _service.GetNewSubscriptionDropdownValues();
            ViewBag.CustomersId = new SelectList(subscriptionDropdownsData.Customers, "CustomersId", "IdNumber");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("RegistrationNumber,Street,StartDate,EndDate,SubscriptionVariant,Active,Paid,CustomersId")]Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                var subscriptionDropdownsData = await _service.GetNewSubscriptionDropdownValues();
                ViewBag.CustomersId = new SelectList(subscriptionDropdownsData.Customers, "CustomersId", "IdNumber");
                return View(subscription);
            }
            await _service.AddAsync(subscription);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            var subscriptionDropdownsData = await _service.GetNewSubscriptionDropdownValues();
            ViewBag.CustomersId = new SelectList(subscriptionDropdownsData.Customers, "CustomersId", "IdNumber");
            var subscriptionEdit = await _service.GetByIdAsync(id);
            if (subscriptionEdit == null) return View("NotFound");


            return View(subscriptionEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SubscriptionId,RegistrationNumber,Street,StartDate,EndDate,SubscriptionVariant,Active,Paid,CustomersId")] Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                var subscriptionDropdownsData = await _service.GetNewSubscriptionDropdownValues();
                ViewBag.CustomersId = new SelectList(subscriptionDropdownsData.Customers, "CustomersId", "IdNumber");
                return View(subscription);
            }
            await _service.UpdateAsync(id, subscription);
            return RedirectToAction(nameof(Index));
        }

        //Delete
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var subscriptionDelete = await _service.GetByIdAsync(id);
            if (subscriptionDelete == null) return View("NotFound");


            return View(subscriptionDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptionDelete = await _service.GetByIdAsync(id);
            if (subscriptionDelete == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Details
        public async Task<IActionResult> Details(int id)
        {
            var subscriptionDetails = await _service.GetByIdAsync(id);
            if (subscriptionDetails == null) return View("NotFound");


            return View(subscriptionDetails);
        }
    }
}
