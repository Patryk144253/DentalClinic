using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Models
{
    public class User : IdentityUser<int>
    {
        public UserType UserType { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IList<Visit> Visits { get; set; }
    }
}
