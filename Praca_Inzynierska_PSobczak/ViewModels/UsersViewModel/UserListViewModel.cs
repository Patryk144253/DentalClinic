using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.ViewModels.UsersViewModel
{
    public class UserListViewModel
    {
        public IEnumerable<UserListItemViewModel> Users { get; set; }
    }
}
