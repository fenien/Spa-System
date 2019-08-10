using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.Beauticians
{
    public class DetailsModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DetailsModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public Beautician Beautician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beautician = await _context.Beautician
                .Include(a => a.BeauticianAppointments)
                .ThenInclude(c => c.Customer).FirstOrDefaultAsync(m => m.ID == id);

            if (Beautician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
