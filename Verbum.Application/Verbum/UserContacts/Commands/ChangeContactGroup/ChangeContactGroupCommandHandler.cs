using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.UserContacts.Commands.ChangeContactGroup
{
    public class ChangeContactGroupCommandHandler :IRequestHandler<ChangeContactGroupCommand>
    {
        private readonly IVerbumDbContext _dbContext;

        public ChangeContactGroupCommandHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Unit> Handle(ChangeContactGroupCommand request, CancellationToken cancellationToken) {
            var contact = await _dbContext.UserContacts.FirstOrDefaultAsync(c => c.Id == request.ContactId);

            if (contact == null) {
                throw new NotFoundException(nameof(UserContact), request.ContactId);
            }

            var contactGroup = await _dbContext.contactGroups.FirstOrDefaultAsync(g => g.Id == request.GroupId);

            if (contactGroup == null) {
                throw new NotFoundException(nameof(ContactGroup), request.GroupId);
            }

            contact.GroupId = request.GroupId;
            contact.Name = request.ContactName;

            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
