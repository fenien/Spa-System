using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa_System.Models;

namespace Spa_System.Pages.PackageTreatments
{
    public class CreateModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;
        public int PackageID { get; set; }
        public CreateModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            PackageID = id;
            ViewData["PackageID"] = new SelectList(_context.Packages, "ID", "PackageName", id);
            ViewData["TreatmentID"] = new SelectList(_context.Treatment, "ID", "Name");

            return Page();
        }

        [BindProperty]
        public PackageTreatment PackageTreatment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PackageTreatment.Add(PackageTreatment);
            await _context.SaveChangesAsync();

            return Redirect("../Packages/Details?id="+ PackageTreatment.PackageID);
        }
    }
}