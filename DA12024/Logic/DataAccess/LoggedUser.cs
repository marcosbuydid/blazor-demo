using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DataAccess
{
    public static class LoggedUser
    {
        public static User? Current { get; set; }
    }
}
