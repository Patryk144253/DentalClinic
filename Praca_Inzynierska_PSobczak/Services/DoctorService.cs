using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Services
{
    public class DoctorService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DoctorService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IList<Doctor> GetDoctorToDropdown()
        {
            var doctors = applicationDbContext.Doctors.ToList();

            return doctors;
        }
    }
}
