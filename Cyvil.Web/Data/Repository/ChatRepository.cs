using Cyvil.Web.Domain;

namespace Cyvil.Web.Data.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;

        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ChatMessage GetMessageById(long messageId)
        {
            var model = _context.ChatMessages
                .Where(m => m.Id == messageId)
                .FirstOrDefault();
            return model!;
        }
    }
}