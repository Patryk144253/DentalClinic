using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Models
{
    public class Visit
    {
        [Key]
        public int VisitId { get; set; }

        public string VisitsDescription { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [DisplayFormat(DataFormatString = "0:dd-MM-yyyy",ApplyFormatInEditMode =true)]
        public DateTime VisitDate { get; set; }
    }
}
