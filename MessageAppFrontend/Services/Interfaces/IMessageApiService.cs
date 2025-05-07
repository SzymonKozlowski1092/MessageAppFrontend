using MessageAppFrontend.Common;
using MessageAppFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Services.Interfaces
{
    public interface IMessageApiService
    {
        Task<ApiResponse> SendMessage(NewMessage newMessage);
    }
}
