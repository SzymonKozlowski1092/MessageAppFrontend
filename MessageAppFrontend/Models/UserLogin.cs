using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class UserLogin
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserLogin()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
        public UserLogin(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
