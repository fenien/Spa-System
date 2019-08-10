using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.PackageAppointments
{
    public class DetailsModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DetailsModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
