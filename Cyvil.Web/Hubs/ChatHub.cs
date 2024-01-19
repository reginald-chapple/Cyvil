using Microsoft.AspNetCore.SignalR;

namespace Cyvil.Web.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId() => Context.ConnectionId;
    }
}
