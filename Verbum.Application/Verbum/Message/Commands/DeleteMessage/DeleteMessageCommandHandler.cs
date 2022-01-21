using MediatR;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Commands.DeleteMessage
{
    public class DeleteMessageCommandHandler :IRequestHandler<DeleteMessageCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public DeleteMessageCommandHandler(IVerbumDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteMessageCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Messages
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) {
                throw new NotFoundException(nameof(Messages), request.Id);
            }

            _dbContext.Messages.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        } 
    }
}
