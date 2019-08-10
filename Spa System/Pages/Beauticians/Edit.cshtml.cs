using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.Beauticians
{
    public class EditModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public EditModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beautician Beautician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beautician = await _context.Beautician.FirstOrDefaultAsync(m => m.ID == id);

            if (Beautician == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beautician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeauticianExists(Beautician.ID))
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

        private bool BeauticianExists(int id)
        {
            return _context.Beautician.Any(e => e.ID == id);
        }
    }
}
