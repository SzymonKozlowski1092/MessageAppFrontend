using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppFrontend.Models
{
    public class NewChatInvitation
    {
        public NewChatInvitation()
        {
            ChatId = default;
            InvitedUserId = default;
        }
        public NewChatInvitation(Guid chatId, Guid invitedUserId)
        {
            ChatId = chatId;
            InvitedUserId = invitedUserId;
        }

        public Guid ChatId { get; set; }
        public Guid InvitedUserId { get; set; }
    }
}
