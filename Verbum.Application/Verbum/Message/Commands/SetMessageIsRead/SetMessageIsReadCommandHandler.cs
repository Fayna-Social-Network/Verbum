using MediatR;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.Message.Commands.SetMessageIsRead
{
    public class SetMessageIsReadCommandHandler :IRequestHandler<SetMessageIsReadCommand>
    {

        IVerbumDbContext _dbContext;

        public SetMessageIsReadCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;


        public async Task<Unit> Handle(SetMessageIsReadCommand request, CancellationToken cancellationToken) {
            
            var message = await _dbContext.Messages.FindAsync(new object[] { request.Id }, cancellationToken);

            if (message == null || message.UserId != request.UserId)
            {
               throw new NotFoundException(nameof(Messages), request.Id);
            }

            message.IsRead = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
