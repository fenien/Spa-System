using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.PackageTreatments
{
    public class EditModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public EditModel(Spa_System.Models.Spa_SystemContext context)
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
                .Include(c => c.Treatment)
                .Include(c => c.Package).FirstOrDefaultAsync(m => m.ID == id);

            if (PackageTreatment == null)
            {
                return NotFound();
            }

            ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "PackageName");
            ViewData["TreatmentID"] = new SelectList(_context.Treatment, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PackageTreatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageTreatmentExists(PackageTreatment.ID))
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

        private bool PackageTreatmentExists(int id)
        {
            return _context.PackageTreatment.Any(e => e.ID == id);
        }
    }
}
