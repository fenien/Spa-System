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
    public class DeleteModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public DeleteModel(Spa_System.Models.Spa_SystemContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beautician = await _context.Beautician.FindAsync(id);

            if (Beautician != null)
            {
                _context.Beautician.Remove(Beautician);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
