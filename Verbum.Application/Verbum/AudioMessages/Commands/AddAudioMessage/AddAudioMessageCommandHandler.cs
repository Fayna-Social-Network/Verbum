using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Hubs;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommandHandler :IRequestHandler<AddAudioMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddAudioMessageCommandHandler(IVerbumDbContext dbContext, VerbumHubRepository hubContext) => 
            (_dbContext, _verbumHubRepository) = (dbContext, hubContext);

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

            await _verbumHubRepository.NotificateUserForMessage(message);

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
