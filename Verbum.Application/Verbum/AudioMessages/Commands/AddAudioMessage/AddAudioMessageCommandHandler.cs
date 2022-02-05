using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommandHandler :IRequestHandler<AddAudioMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IHubContext<VerbumHub> _hubContext;

        public AddAudioMessageCommandHandler(IVerbumDbContext dbContext, IHubContext<VerbumHub> hubContext) => 
            (_dbContext, _hubContext) = (dbContext, hubContext);

        public async Task<Guid> Handle(AddAudioMessageCommand request, CancellationToken cancellationToken) {
            
            var message = new Messages
            {
                Id = Guid.NewGuid(),
                Text = "[:audio_message:]",
                Timestamp = DateTime.UtcNow,
                Seller = request.SellerId,
                UserId = request.UserId,
                IsRead = false
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
           

            var audioMessage = new AudioMessage
            {
                path = request.Path,
                MessageId = message.Id
            };

            await _dbContext.audioMessages.AddAsync(audioMessage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);


           

            return message.Id;
           

        }
    }
}
