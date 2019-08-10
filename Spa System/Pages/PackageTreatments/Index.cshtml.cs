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
    public class IndexModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public IndexModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IList<PackageTreatment> PackageTreatment { get;set; }

        public async Task OnGetAsync()
        {
            PackageTreatment = await _context.PackageTreatment.
                Include(c => c.Package)
                .Include(c => c.Treatment).ToListAsync();
        }
    }
}
