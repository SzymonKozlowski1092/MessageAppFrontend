namespace MessageAppFrontend.Models
{
    public class ChatInvitation
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public string ChatName { get; set; } = string.Empty;
        public string InvitedByUsername { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }
}
