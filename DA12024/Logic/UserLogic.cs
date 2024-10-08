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
        private readonly MemoryDB _memoryDB;

        public UserLogic(MemoryDB memoryDB)
        {
            _memoryDB = memoryDB;
        }

        public void AddUser(UserDTO user)
        {
            ValidateUserEmail(user.Email);
            _memoryDB.Users.Add(user.ToEntity());
        }

        public UserDTO GetUserByEmail(string email)
        {
            User user = _memoryDB.Users.FirstOrDefault(user => user.Email == email);
            if (user == null)
            {
                throw new ArgumentException("Cannot find user with this email");
            }
            return UserDTO.FromEntity(user);
        }

        private void ValidateUserEmail(string email)
        {
            foreach (var user in _memoryDB.Users)
            {
                if (user.Email == email)
                {
                    throw new ArgumentException("There`s a user already defined with that email");
                }
            }
        }
    }
}
