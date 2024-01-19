using Cyvil.Web.Domain;

namespace Cyvil.Web.Models
{
    public class PrivateChatViewModel
    {
        // public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public Chat? Chat { get; set; }
    }
}