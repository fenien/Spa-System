using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_System.Models
{
    public class PackageAppointment
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime? AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Appointment Time")]
        public DateTime? AppointmentTime { get; set; }

        [Display(Name = "Discount Given")]
        public int discountGiven { get; set; }
        public string Status { get; set; }

        public int? BeauticianID { get; set; }
        public int PackageID { get; set; }
        public int CustomerID { get; set; }

        public Beautician Beautician { get; set; }
        public Package CustomerPackage { get; set; }
        public Customer Customer { get; set; }

    }
}
