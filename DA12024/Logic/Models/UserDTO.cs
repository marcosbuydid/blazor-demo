using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string Name {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User ToEntity()
        {
            return new User(Id, Name, LastName, Email, Password, Role)
            {
                Id = Id,
                Name = Name,
                LastName = LastName,
                Email = Email,
                Password = Password,
                Role = Role
            };
        }

        public static UserDTO FromEntity(User user)
        {
            return new UserDTO()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
