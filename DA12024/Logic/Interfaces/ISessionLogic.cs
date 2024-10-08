using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ISessionLogic
    {
        void Login(string username, string password);
        User? GetLoggedUser();
    }
}
