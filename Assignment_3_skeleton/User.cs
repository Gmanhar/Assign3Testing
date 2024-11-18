using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return Id == other.Id &&
                       Name == other.Name &&
                       Email == other.Email &&
                       Password == other.Password;
            }
            return false;
        }

        public override string ToString()
        {
            return $"User [Id={Id}, Name={Name}, Email={Email}]";
        }
    }
}