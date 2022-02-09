using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand
{
    public class AddImagesMessageCommandHandler :IRequestHandler<AddImagesMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddImagesMessageCommandHandler(IVerbumDbContext verbumDb, VerbumHubRepository verbumHubRepository) => 
            (_dbContext, _verbumHubRepository) = (verbumDb, verbumHubRepository);

        public async Task<Guid> Handle(AddImagesMessageCommand request, CancellationToken cancellationToken) {
           
            var message = new Messages
            {
                Id = Guid.NewGuid(),
                Text = "[:image_message:]",
                Timestamp = DateTime.UtcNow,
                Seller = request.SellerId,
                UserId = request.UserId,
                IsRead = false
            };

            await _verbumHubRepository.NotificateUserForMessage(message);
            
            await _dbContext.Messages.AddAsync(message, cancellationToken);

            var imageAlbum = new ImageAlbum
            {
                Id = Guid.NewGuid(),
                Header = request.Header,
                Description = request.Description,
                MessageId = message.Id
            };

            await _dbContext.ImageAlbums.AddAsync(imageAlbum, cancellationToken);

            if (request.DbImagePath != null)
            {
                foreach (string path in request.DbImagePath)
                {
                    var imageMessage = new ImageMessage
                    {
                        Path = path,
                        ImageAlbumId = imageAlbum.Id
                    };
                    await _dbContext.Images.AddAsync(imageMessage, cancellationToken);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return imageAlbum.Id;
        }
    }
}
