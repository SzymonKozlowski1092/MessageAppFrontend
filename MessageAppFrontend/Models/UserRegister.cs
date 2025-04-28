using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class UserRegister
    {
        public string? Username { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public UserRegister() 
        {
            Username = string.Empty;
            DisplayName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }
        public UserRegister(string username, string displayName, string email, string password, string confirmPassword)
        {
            Username = username;
            DisplayName = displayName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
