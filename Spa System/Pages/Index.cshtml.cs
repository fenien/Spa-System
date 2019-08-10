using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public IndexModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IList<PackageAppointment> Appointment { get; set; }
        public IList<Package> Packages { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<PackageAppointment> sortedAppointments = _context.PackageAppointment
                .Include(b => b.Beautician)
                .Include(c => c.Customer)
                .AsQueryable();

            sortedAppointments = sortedAppointments
                .Where(d => d.AppointmentDate != null)
                .OrderBy(s => s.AppointmentDate);

            Appointment = await sortedAppointments.AsNoTracking().ToListAsync();

            Packages = await _context.Packages
                .Include(p => p.PackageTreatments)
                .ThenInclude(t => t.Treatment)
                .Take(3)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
