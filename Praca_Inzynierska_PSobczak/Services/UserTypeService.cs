using Praca_Inzynierska_PSobczak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Praca_Inzynierska_PSobczak.Services
{
    public class UserTypeService
    {
        public IList<string> getEnums()
        {
            return Enum.GetNames(typeof(UserType)).ToList();
        }
    }
}
