﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Pages.PackageAppointments
{
    public class IndexModel : PageModel
    {
        private readonly Spa_System.Models.Spa_SystemContext _context;

        public IndexModel(Spa_System.Models.Spa_SystemContext context)
        {
            _context = context;
        }

        public IList<PackageAppointment> PackageAppointment { get;set; }

        public async Task OnGetAsync()
        {
            PackageAppointment = await _context.PackageAppointment
                .Include(p => p.Beautician)
                .Include(p => p.Customer)
                .Include(p => p.CustomerPackage)
                .Where(d => d.AppointmentTime != null)
                .OrderBy(p => p.AppointmentDate)
                .ThenBy(p => p.AppointmentTime).ToListAsync();
        }
    }
}
