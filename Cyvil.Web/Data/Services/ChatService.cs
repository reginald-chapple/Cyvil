using System.Security.Claims;
using Cyvil.Web.Domain;
using Cyvil.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyvil.Web.Data.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }

        private string PrivateChatDisplayName(string chatName, ClaimsPrincipal User)
        {
            string[] names = chatName.Split(":");
            var result = Array.Find(names, element => element != User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            return result!;
        }

        public async Task<ChatViewModel> GetChatModelAsync(Chat chat, ClaimsPrincipal User)
        {
            string avatar;
            string name;

            if (chat.Type == ChatType.Private)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == PrivateChatDisplayName(chat.Name, User));

                name = user!.FullName;

                if (string.IsNullOrEmpty(user.Image))
                {
                    avatar = user!.FullName[..1];
                }
                else
                {
                    avatar = user!.Image;
                }

            }
            else
            {
                name = chat.Name;
                avatar = chat.Name[..1];
            }

            var model = new ChatViewModel
            {
                ChatId = chat.Id,
                Name = name,
                Avatar = avatar,
            };

            return model;
        }
    }
}