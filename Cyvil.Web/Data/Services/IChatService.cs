using System.Security.Claims;
using Cyvil.Web.Domain;
using Cyvil.Web.Models;

namespace Cyvil.Web.Data.Services
{
    public interface IChatService
    {
        Task<ChatViewModel> GetChatModelAsync(Chat chat, ClaimsPrincipal User);

    }
}