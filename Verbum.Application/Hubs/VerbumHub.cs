using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs.dtos;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Hubs
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


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _dbContext.Users.SingleAsync(i => i.HubConnectionId == Context.ConnectionId);
            if (user != null)
            {
                user.HubConnectionId = "";
                user.IsOnline = false;
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                await Clients.All.SendAsync("userIsOffline", user.NickName);
            }



            await base.OnDisconnectedAsync(exception);
        }

        public async Task ReactionActivity(ReactionActivityDto dto) {

            await Clients.All.SendAsync("ReactionActive", dto);

        }

        public async Task UserTypingMessage(UserTypingDto dto) {
            var user = await _dbContext.Users.SingleAsync(u => u.Id == dto.User);
            if (user != null) {
                if (user.IsOnline) {
                    await Clients.Client(user.HubConnectionId).SendAsync("TypingMessage",  dto.FromWho);
                }
            }
        }

        public async Task SendMessage(Messages message) =>
            await Clients.All.SendAsync("receiveMessage", message);


        public async Task SuccessRegistration(string nickname) {
            await Clients.All.SendAsync("userIsOnline", nickname);
        }


        public async Task RegisterUserOnline(string NickName)
        {
            var user = await _dbContext.Users.SingleAsync(i => i.NickName == NickName);
            if (user != null)
            {
                user.IsOnline = true;
                user.HubConnectionId = Context.ConnectionId;

                await _dbContext.SaveChangesAsync(CancellationToken.None);

                await Clients.Client(Context.ConnectionId).SendAsync("regOk");

            }

        }
    }
}
