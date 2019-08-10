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
    public class DeleteModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DeleteModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PackageTreatment = await _context.PackageTreatment.FindAsync(id);

            if (PackageTreatment != null)
            {
                _context.PackageTreatment.Remove(PackageTreatment);
                await _context.SaveChangesAsync();
            }

            return Redirect("../Packages/Details?id=" + PackageTreatment.PackageID);
        }
    }
}
