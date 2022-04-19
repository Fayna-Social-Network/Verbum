using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage
{
    public class CreateVideoMessageCommandHandler :IRequestHandler<CreateVideoMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public CreateVideoMessageCommandHandler(IVerbumDbContext verbumDb, VerbumHubRepository verbumHub) => 
            (_dbContext, _verbumHubRepository) = (verbumDb, verbumHub);

        public async Task<Guid> Handle(CreateVideoMessageCommand request, CancellationToken cancellationToken) {

            var message = new Messages
            {
                Id = Guid.NewGuid(),
                Text = "[:video_message:]",
                Seller = request.UserId,
                Timestamp = DateTime.UtcNow,
                IsRead = false,
                UserId = request.ContactId
            };

            await _verbumHubRepository.NotificateUserForMessage(message);
            await _dbContext.Messages.AddAsync(message);

            var videoMessage = new VideoMessage
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Path = request.VideoPath,
                MessageId = message.Id
            };

            await _dbContext.videoMessages.AddAsync(videoMessage);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id; 

        }
    }
}
