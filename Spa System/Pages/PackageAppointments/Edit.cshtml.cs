using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.PackageAppointments
{
    public class EditModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public EditModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PackageAppointment PackageAppointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PackageAppointment = await _context.PackageAppointment
                .Include(p => p.Beautician)
                .Include(p => p.Customer)
                .Include(p => p.CustomerPackage).FirstOrDefaultAsync(m => m.ID == id);

            if (PackageAppointment == null)
            {
                return NotFound();
            }
           ViewData["BeauticianID"] = new SelectList(_context.Beautician, "ID", "Name");
           ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "Name");
           ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "PackageName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PackageAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageAppointmentExists(PackageAppointment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("../Customers/Details?id=" + PackageAppointment.CustomerID);
        }

        private bool PackageAppointmentExists(int id)
        {
            return _context.PackageAppointment.Any(e => e.ID == id);
        }
    }
}
