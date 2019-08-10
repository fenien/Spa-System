using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.PackageTreatments
{
    public class DetailsModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DetailsModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public PackageTreatment PackageTreatment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PackageTreatment = await _context.PackageTreatment
                .Include(t => t.Treatment)
                .Include(p => p.Package).FirstOrDefaultAsync(m => m.ID == id);

            if (PackageTreatment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
