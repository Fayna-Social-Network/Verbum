using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.WebApi.Hubs
{
   
    public class VerbumHub :Hub
    {
        private readonly IVerbumDbContext _dbContext;

        public VerbumHub(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception? exception) {
            var user = await _dbContext.Users.SingleAsync(i => i.HubConnectionId == Context.ConnectionId);
            if (user != null) {
                user.HubConnectionId = "";
                user.IsOnline = false;
                await _dbContext.SaveChangesAsync(CancellationToken.None);
            }

            await base.OnDisconnectedAsync(exception);
        }



        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);


        public async Task RegisterUserOnline(string NickName) {
           var user = await _dbContext.Users.SingleAsync(i => i.NickName == NickName);
            if (user != null) {
                user.IsOnline = true;
                user.HubConnectionId = Context.ConnectionId;

               await _dbContext.SaveChangesAsync(CancellationToken.None);
            }

        }

       

    }
}
