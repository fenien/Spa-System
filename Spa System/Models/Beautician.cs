using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Spa_System.Models
{
    public class Beautician
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Hey, its too SHORT, This is not a phone number!")]
        [RegularExpression(@"^[0-9\-\ ]*$", ErrorMessage = "Only numbers, dashes are allowed!")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        public int Age { get; set; }

        public ICollection<PackageAppointment> BeauticianAppointments { get; set; }

    }
}
