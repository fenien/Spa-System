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
    public class IndexModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public IndexModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IList<Treatment> Treatment { get;set; }

        public async Task OnGetAsync()
        {
            Treatment = await _context.Treatment.ToListAsync();
        }
    }
}
