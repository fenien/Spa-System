using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_System.Models
{
    public class Treatment
    {
        public int ID { get; set; }

        [Display(Name = "Treatment Name")]
        [Required]
        public string Name { get; set; }
        public ICollection<PackageTreatment> PackageTreatments { get; set; }
    }
}
