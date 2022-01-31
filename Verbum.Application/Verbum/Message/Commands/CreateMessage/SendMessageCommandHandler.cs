using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Message.Commands.CreateMessage
{
    public class SendMessageCommandHandler :IRequestHandler<SendMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IHubContext<VerbumHub> _hubContext;

        public SendMessageCommandHandler(IVerbumDbContext dbContext, IHubContext<VerbumHub> hubContext) =>
            (_dbContext, _hubContext) = (dbContext, hubContext);

        public async Task<Guid> Handle(SendMessageCommand request, CancellationToken
            cancellationToken)
        {
            var message = new Messages
            {
                Id = request.Id,
                Text = request.Text,
                Seller = request.Seller,
                IsRead = false,
                Timestamp = DateTime.UtcNow,
                UserId = request.UserId
            };


            var recipient = await _dbContext.Users.SingleAsync(r => r.Id == message.UserId);

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

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);


            return message.Id;
        }
    }
}
