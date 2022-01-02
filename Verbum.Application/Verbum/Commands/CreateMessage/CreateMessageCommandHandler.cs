using MediatR;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;

        public CreateMessageCommandHandler(IVerbumDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateMessageCommand request,
            CancellationToken cancellationToken)
        {
            var message = new Message
            {
                UserId = request.UserId,
                Text = request.Text,
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow
            };

            await _dbContext.Messages.AddAsync(message, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return message.Id;
        }
    }
}
