using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual IList<Visit> Visits { get; set; }
    }
}
