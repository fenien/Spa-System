using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_System.Models
{
    public class Package
    {
        public int ID { get; set; }

        [Display(Name = "Package Name")]
        public String PackageName { get; set; }
        public int Price { get; set; }

        public ICollection<PackageTreatment> PackageTreatments { get; set; }
        public ICollection<PackageAppointment> CustomerPackages { get; set; }

    }
}
