using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_jwt_authentication.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public User()
        {

        }
        public User(int _id, string _email, string _role, string _password, string _token)
        {
            Id = _id;
            Email = _email;
            Role = _role;
            Password = _password;
            Token = _token;
        }

        public User(User _user)
        {
            Id = _user.Id;
            Email = _user.Email;
            Role = _user.Role;
            Password = _user.Password;
            Token = _user.Token;
        }
    }

    public static class UserExtensions
    {
        public static User WithoutPassword(this User value)
        {
            value.Password = "";
            return value;
        }
    }
}
