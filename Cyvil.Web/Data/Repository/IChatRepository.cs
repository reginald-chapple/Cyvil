using Cyvil.Web.Domain;

namespace Cyvil.Web.Data.Repository
{
    public interface IChatRepository
    {
        ChatMessage GetMessageById(long messageId);
    }
}