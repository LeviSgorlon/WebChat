using System.ComponentModel.DataAnnotations;

namespace WebChat.Models
{
    public class ChatEntryModel
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
    }
}
