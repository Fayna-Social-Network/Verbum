using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.AudioMessages.Commands.AddAudioMessage
{
    public class AddAudioMessageCommandHandler :IRequestHandler<AddAudioMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly VerbumHubRepository _verbumHubRepository;

        public AddAudioMessageCommandHandler(IVerbumDbContext dbContext, VerbumHubRepository hubContext) => 
            (_dbContext, _verbumHubRepository) = (dbContext, hubContext);

        public async Task<Guid> Handle(AddAudioMessageCommand request, CancellationToken cancellationToken) {
            
            var message = new ChatMessage
            {
                Id = Guid.NewGuid(),
                Text = "[:audio_message:]",
                Timestamp = DateTime.UtcNow,
                Seller = request.SellerId,
                ChatId = request.ChatId,
                IsRead = false
            };

            await _verbumHubRepository.NotificateUserForMessage<ChatMessage>(message, request.UserId);

            await _dbContext.chatMessages.AddAsync(message, cancellationToken);

            var audioMessage = new ChatAudioMessage
            {
                Id = Guid.NewGuid(),
                ChatMessageId = message.Id
            };

            if(request.audioFiles != null) 
            {
                foreach (AudioFileModel audioFilePaths in request.audioFiles)
                {
                    var audioFile = new UserFile
                    {
                        Id = Guid.NewGuid(),
                        Type = "audio",
                        Name = "audio message",
                        Path = audioFilePaths.AudioFilePath,
                        PreviewImagePath = audioFilePaths.ImagePreviewPath,
                        UserId = request.SellerId
                    };

                    await _dbContext.usersFiles.AddAsync(audioFile, cancellationToken);

                    audioMessage.userFiles!.Add(audioFile);
                }
            }

           
            await _dbContext.chatAudioMessages.AddAsync(audioMessage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id;
           

        }
    }
}
