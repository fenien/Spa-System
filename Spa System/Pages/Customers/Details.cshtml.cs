using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DetailsModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer
                .Include(a => a.CustomerAppointments)
                    .ThenInclude(a => a.Beautician)
                .Include(a => a.CustomerAppointments)
                    .ThenInclude(a => a.CustomerPackage)
                .FirstOrDefaultAsync(m => m.ID == id);


            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
