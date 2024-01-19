using Cyvil.Web.Domain;

namespace Cyvil.Web.Models
{
    public class ChatMessageModel
    {
        public ChatMessage? Message { get; set; }
        public UserModel? Author { get; set; }
    }
}