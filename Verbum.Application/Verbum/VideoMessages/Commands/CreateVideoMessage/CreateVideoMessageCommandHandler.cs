using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.VideoMessages.Commands.CreateVideoMessage
{
    public class CreateVideoMessageCommandHandler :IRequestHandler<CreateVideoMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public CreateVideoMessageCommandHandler(IVerbumDbContext verbumDb, VerbumHubRepository verbumHub) => 
            (_dbContext, _verbumHubRepository) = (verbumDb, verbumHub);

        public async Task<Guid> Handle(CreateVideoMessageCommand request, CancellationToken cancellationToken) {

            var message = new ChatMessage
            {
                Id = Guid.NewGuid(),
                Text = "[:video_message:]",
                Seller = request.UserId,
                Timestamp = DateTime.UtcNow,
                IsRead = false,
                ChatId = request.ChatId
            };

            await _verbumHubRepository.NotificateUserForMessage<ChatMessage>(message, request.ContactId);
            await _dbContext.chatMessages.AddAsync(message);

            var videoMessage = new ChatVideoMessage
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                ChatMessageId = message.Id
            };

            await _dbContext.chatVideoMessages.AddAsync(videoMessage);

            if(request.videoFiles != null) 
            {
                foreach(VideoFileModel video in request.videoFiles) 
                {
                    var videoFile = new UserFile
                    {
                        Id = Guid.NewGuid(),
                        Type = "video",
                        Name = "video_file",
                        Path = video.VideoFilePath,
                        PreviewImagePath = video.VideoImagePreview,
                        UserId = request.UserId
                    };

                    await _dbContext.usersFiles.AddAsync(videoFile);

                    videoMessage.userFiles!.Add(videoFile);

                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id; 

        }
    }
}
