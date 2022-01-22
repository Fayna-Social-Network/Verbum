using MediatR;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.UserContacts.Commands.DeleteContactFromUser
{
    public class DeleteContactFromUserCommandHandler: IRequestHandler<DeleteContactFromUserCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public DeleteContactFromUserCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteContactFromUserCommand request, CancellationToken cancellationToken) {
            var entity = await _dbContext.UserContacts
                .FindAsync(new object[] { request.contactId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserContact), request.contactId);
            }

            _dbContext.UserContacts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
