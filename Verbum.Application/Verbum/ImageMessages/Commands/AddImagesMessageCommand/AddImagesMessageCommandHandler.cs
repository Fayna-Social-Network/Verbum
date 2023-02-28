using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.ImageMessages.Commands.AddImagesMessageCommand
{
    public class AddImagesMessageCommandHandler :IRequestHandler<AddImagesMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddImagesMessageCommandHandler(IVerbumDbContext verbumDb, VerbumHubRepository verbumHubRepository) => 
            (_dbContext, _verbumHubRepository) = (verbumDb, verbumHubRepository);

        public async Task<Guid> Handle(AddImagesMessageCommand request, CancellationToken cancellationToken) {
           
            var message = new ChatMessage
            {
                Id = Guid.NewGuid(),
                Text = "[:image_message:]",
                Timestamp = DateTime.UtcNow,
                Seller = request.SellerId,
                ChatId = request.ChatId,
                IsRead = false
            };

            await _verbumHubRepository.NotificateUserForMessage<ChatMessage>(message, request.UserId);
            
            await _dbContext.chatMessages.AddAsync(message, cancellationToken);

            var imageAlbum = new ChatImageMessage
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                ChatMessageId = message.Id
            };

            await _dbContext.chatImageMessages.AddAsync(imageAlbum, cancellationToken);

            if (request.ImagePaths != null)
            {
                foreach (string path in request.ImagePaths)
                {
                    var imageFile = new UserFile
                    {
                        Id = Guid.NewGuid(),
                        Type = "Image",
                        Name = "image_file",
                        Path = path,
                        UserId = request.SellerId
                    };

                    await _dbContext.usersFiles.AddAsync(imageFile, cancellationToken);

                    imageAlbum.userFiles!.Add(imageFile);
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            return message.Id;
        }
    }
}
