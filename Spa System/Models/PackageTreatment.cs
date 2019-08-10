using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_System.Models
{
    public class PackageTreatment
    {
        public int ID { get; set; }

        [Display(Name = "Package Name")]
        public int PackageID { get; set; }

        [Display(Name = "Treatment Name")]
        public int TreatmentID { get; set; }

        public Package Package { get; set; }
        public Treatment Treatment { get; set; }
    }
}
        