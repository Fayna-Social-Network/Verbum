using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.ContactGroups.Commands.UpdateContactGroup
{
    public class UpdateContactGroupCommandHandler :IRequestHandler<UpdateContactGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public UpdateContactGroupCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateContactGroupCommand request, CancellationToken cancellationToken) {
            
            var entity = await _dbContext.contactGroups.FirstOrDefaultAsync(g => g.Id == request.GroupId);

            if (entity == null) {
                throw new NotFoundException(nameof(ContactGroup), request.GroupId);
            }

            entity.GroupName = request.NewGroupName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
