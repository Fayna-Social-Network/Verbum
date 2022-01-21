using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Message.Commands.SetMessageIsRead
{
    public class SetMessageIsReadCommandHandler :IRequestHandler<SetMessageIsReadCommand>
    {

        IVerbumDbContext _dbContext;

        public SetMessageIsReadCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;


        public async Task<Unit> Handle(SetMessageIsReadCommand request, CancellationToken cancellationToken) {
            
            var message = await _dbContext.Messages.SingleOrDefaultAsync(m => m.Id == request.Id);

            if (message != null)
            {
                message.IsRead = true;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
