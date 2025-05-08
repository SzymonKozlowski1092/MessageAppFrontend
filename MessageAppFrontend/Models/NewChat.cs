using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class NewChat
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
    }
}
