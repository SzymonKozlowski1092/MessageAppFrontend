using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class NewMessage
    {
        public string Content { get; set; } = string.Empty;
        public Guid ChatId { get; set; }
    }
}
