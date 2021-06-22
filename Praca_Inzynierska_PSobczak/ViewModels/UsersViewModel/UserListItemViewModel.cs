using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.UsersViewModel
{
    public class UserListItemViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

    }
}
