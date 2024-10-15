using Domain;
using Logic.DataAccess;
using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SessionLogic : ISessionLogic
    {
        private readonly IRepository<User> _userRepository;

        public SessionLogic(IRepository<User> userRepository)
        {
           _userRepository = userRepository;
        }

        public User? GetLoggedUser()
        {
            return LoggedUser.Current;
        }

        public void Login(string email, string password)
        {
            User? userToAuthenticate = _userRepository.Find(user => user.Email == email && user.Password == password);
            if (userToAuthenticate == null)
            {
                throw new ArgumentException("User or password is incorrect, try again");
            }
            LoggedUser.Current = userToAuthenticate;
        }

        public void Logout()
        {
            LoggedUser.Current = null;
        }
    }
}
