using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IUserLogic
    {
        UserDTO GetUserByEmail(string email);
        void AddUser(UserDTO user);
    }
}
