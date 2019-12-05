using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_jwt_authentication.Models
{
    public class UserForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
