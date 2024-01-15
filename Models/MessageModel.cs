namespace Quark_Backend.Models
{
    public class MessageModel
    {
        public required string Email { get; set; }
        public required string Timestamp { get; set; }
        public required string Text { get; set; }
        public required string Username {get; set;}
    }
}