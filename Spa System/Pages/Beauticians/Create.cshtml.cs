using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa_System.Models;

namespace Spa_System.Pages.Beauticians
{
    public class CreateModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public CreateModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Beautician Beautician { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beautician.Add(Beautician);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}