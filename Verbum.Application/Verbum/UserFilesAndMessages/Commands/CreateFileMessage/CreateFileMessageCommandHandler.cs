using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;
using Verbum.Domain.MessagesDb;

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

            var message = new Messages
            {
                Id = new Guid(),
                Text = "[:fileMessage:]",
                Seller = request.Seller,
                IsRead = false,
                Timestamp = DateTime.UtcNow,
                UserId = request.UserId
            };

            await _verbumHubRepository.NotificateUserForMessage(message);

            await _dbContext.Messages.AddAsync(message, cancellationToken);

            var fileMessage = new FileMessage
            {
                Id = new Guid(),
                Path = request.Path,
                Type = request.Type,
                MessageId = message.Id
            };

            await _dbContext.fileMessages.AddAsync(fileMessage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return fileMessage.Id;

        }  
    }
}
