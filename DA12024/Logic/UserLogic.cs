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
    public class UserLogic : IUserLogic
    {
        private readonly IRepository<User> _userRepository;

        public UserLogic(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserDTO user)
        {
            ValidateUserEmail(user.Email);
            _userRepository.Add(user.ToEntity());
        }

        public UserDTO GetUserByEmail(string email)
        {
            User? user = _userRepository.Find(user => user.Email == email);
            if (user == null)
            {
                throw new ArgumentException("Cannot find user with this email");
            }
            return UserDTO.FromEntity(user);
        }

        private void ValidateUserEmail(string email)
        {
            foreach (var user in _userRepository.FindAll())
            {
                if (user.Email == email)
                {
                    throw new ArgumentException("There`s a user already defined with that email");
                }
            }
        }
    }
}
