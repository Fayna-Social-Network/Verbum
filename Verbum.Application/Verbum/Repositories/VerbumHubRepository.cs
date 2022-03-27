using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Repositories
{
    public class VerbumHubRepository
    {

        private readonly IVerbumDbContext _dbContext;
        private readonly IHubContext<VerbumHub> _hubContext;

        public VerbumHubRepository(IVerbumDbContext verbumDb, IHubContext<VerbumHub> hub) =>
            (_dbContext, _hubContext) = (verbumDb, hub);

        public async Task NotificateUserForMessage(Messages message) {
            
            var recipient = await _dbContext.Users.SingleOrDefaultAsync(r => r.Id == message.UserId);

            if (recipient != null)
            {
                if (recipient.IsOnline)
                {
                    if (recipient.HubConnectionId != null)
                    {
                        await _hubContext.Clients.Client(recipient.HubConnectionId).SendAsync("acceptMessage", message);
                    }
                }
            }
        }

        public async Task NotificateUserForMessageIsRead(Messages message) {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == message.Seller);

            if (user != null) {
                if (user.IsOnline) {
                    if (user.HubConnectionId != null) {
                        await _hubContext.Clients.Client(user.HubConnectionId).SendAsync("messageIsRead", message);
                    }
                }
            }
        }

        public async Task NotificateUserForMessageIsDelete(Messages message, Guid UserId) {
            Guid recipientId;
            if (message.Seller == UserId)
            {
                recipientId = message.UserId;
            }
            else
            {
                recipientId = message.Seller;
            }

            var recipient = await _dbContext.Users.SingleOrDefaultAsync(r => r.Id == recipientId);

            if (recipient != null)
            {
                if (recipient.IsOnline)
                {
                    if (recipient.HubConnectionId != null)
                    {
                        await _hubContext.Clients.Client(recipient.HubConnectionId).SendAsync("messageIsDelete", message.Id);
                    }
                }
            }
        }

        public async Task NotificateUserForBlocking(Guid UserId, Guid blockingId) {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == UserId);

            if (user != null) {
                if (user.IsOnline) {
                    if (user.HubConnectionId != null) {
                        await _hubContext.Clients.Client(user.HubConnectionId).SendAsync("youAreBlocked", blockingId);
                    }
                }
            }
        } 
    }
}
