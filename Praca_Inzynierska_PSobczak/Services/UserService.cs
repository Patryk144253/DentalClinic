using Praca_Inzynierska_PSobczak.Data;
using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IList<User> GetUserToDropdown()
        {
            var users = applicationDbContext.Users.ToList();

            return users;
        }
    }
}
