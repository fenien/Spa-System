using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spa_System.Models;

namespace Spa_System.Models
{
    public class Spa_SystemContext : DbContext
    {
        public Spa_SystemContext (DbContextOptions<Spa_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<Spa_System.Models.Beautician> Beautician { get; set; }

        public DbSet<Treatment> Treatment { get; set; }

        public DbSet<PackageTreatment> PackageTreatment { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Spa_System.Models.Customer> Customer { get; set; }
        public DbSet<Spa_System.Models.PackageAppointment> PackageAppointment { get; set; }
    }
}
