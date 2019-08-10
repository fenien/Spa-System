using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa_System.Models;

namespace Spa_System.Pages.PackageAppointments
{
    public class CreateModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public CreateModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
        ViewData["BeauticianID"] = new SelectList(_context.Beautician, "ID", "Name");
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "Name", id);
        ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "PackageName");
            return Page();
        }

        [BindProperty]
        public PackageAppointment PackageAppointment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PackageAppointment.Add(PackageAppointment);
            await _context.SaveChangesAsync();

            return Redirect("../Customers/Details?id=" + PackageAppointment.CustomerID);
        }
    }
}