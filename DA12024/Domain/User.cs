using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        private int? id;
        private string name;
        private string lastName;
        private string email;
        private string password;
        private string role;

        public int? Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName cannot be null or empty");
                }
                lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email cannot be null or empty");
                }
                email = value;
            }

        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Password cannot be null or empty");
                }
                password = value;
            }

        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Role cannot be null or empty");
                }
                role = value;
            }

        }

        public User(int? id, string name, string lastname, string email, string password, string role)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
