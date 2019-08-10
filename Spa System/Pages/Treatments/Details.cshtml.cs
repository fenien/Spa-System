using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.Treatments
{
    public class DetailsModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DetailsModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public Treatment Treatment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Treatment = await _context.Treatment
                .Include(p => p.PackageTreatments)
                .ThenInclude(pk => pk.Package)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Treatment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
