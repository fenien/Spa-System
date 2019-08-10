using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_System.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(9, ErrorMessage = "Hey, its too SHORT, This is not a phone number!")]
        [RegularExpression(@"^[0-9\-\ ]*$", ErrorMessage = "Only numbers, dashes are allowed!")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        
        public string Gender { get; set; }

        public int Age { get; set; }

        public ICollection<PackageAppointment> CustomerAppointments { get; set; }

    }
}
