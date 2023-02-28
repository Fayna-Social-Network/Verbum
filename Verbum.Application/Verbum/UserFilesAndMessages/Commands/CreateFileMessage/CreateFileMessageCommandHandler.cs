using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.ChatOnes;
using Verbum.Domain.UserFilesTable;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Commands.CreateFileMessage
{
    public class CreateFileMessageCommandHandler :IRequestHandler<CreateFileMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly CommonRepository _commonRepository;
        private readonly VerbumHubRepository _verbumHubRepository;

        public CreateFileMessageCommandHandler(IVerbumDbContext dbContext, CommonRepository commonRepository, VerbumHubRepository verbumHubRepository)
        {
            _dbContext = dbContext;
            _commonRepository = commonRepository;
            _verbumHubRepository = verbumHubRepository;
        }

        public async Task<Guid> Handle(CreateFileMessageCommand request, CancellationToken cancellationToken) {

            await _commonRepository.IsUserInBlackList(request.UserId, request.Seller);

            var message = new ChatMessage
            {
                Id = new Guid(),
                Text = "[:fileMessage:]",
                Seller = request.Seller,
                IsRead = false,
                Timestamp = DateTime.UtcNow,
                ChatId = request.UserId
            };

            await _verbumHubRepository.NotificateUserForMessage<ChatMessage>(message, request.UserId);

            await _dbContext.chatMessages.AddAsync(message, cancellationToken);

            var fileMessage = new ChatFileMessage
            {
                Id = new Guid(),
                Text = request.Text,
                Description = request.Description,
                ChatMessageId = message.Id
            };

            await _dbContext.chatFileMessages.AddAsync(fileMessage);

            if (request.Paths != null) 
            {
                foreach (string file in request.Paths)
                {
                    var userFile = new UserFile
                    {
                        Id = Guid.NewGuid(),
                        Type = "file",
                        Name = "file_name",
                        Path = file,
                        UserId = request.UserId

                    };

                    await _dbContext.usersFiles.AddAsync(userFile, cancellationToken);

                    fileMessage.userFiles!.Add(userFile);
                }

            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return fileMessage.Id;

        }  
    }
}
