using Microsoft.AspNetCore.SignalR;
using Verbum.Domain;

namespace Verbum.WebApi.Hubs
{
    public class ChatHub :Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
       

    }
}
