using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_jwt_authentication.Entities
{
    public class UserManager
    {
        private List<User> allUsers = new List<User>
        {
            new User
            {
                Id=1,
                Email="sarah.connor@domain.com",
                Password="John",
                Role="Employee"
            },
            new User
            {
                Id=2,
                Email="glenn.quagmire@domain.com",
                Password="giggity",
                Role="Manager"
            }
        };

        public User GetUser(string email, string passwrod)
        {
            return allUsers.SingleOrDefault(x => x.Email == email && x.Password == passwrod);
        }
    }
}
