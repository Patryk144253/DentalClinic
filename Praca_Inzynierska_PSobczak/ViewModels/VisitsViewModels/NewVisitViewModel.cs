using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.VisitsViewModels
{
    public class NewVisitViewModel
    {
        public int VisitId { get; set; }
        public string VisitsDescription { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime VisitDate { get; set; }
    }
}
