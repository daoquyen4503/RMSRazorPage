﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RMSRazorPage.Data;
using RMSRazorPage.Models;

namespace RMSRazorPage.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly RMSRazorPage.Data.ApplicationDbContext _context;

        public EditModel(RMSRazorPage.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment =  await _context.Payments.FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }
            Payment = payment;
           ViewData["ReservationID"] = new SelectList(_context.Reservations, "ReservationID", "Status");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(Payment.PaymentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
