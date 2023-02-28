using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.ContactGroups.Commands.DeleteContactGroup
{
    public class DeleteContactGroupCommandHandler : IRequestHandler<DeleteContactGroupCommand>
    {

        private readonly IVerbumDbContext _dbContext;

        public DeleteContactGroupCommandHandler(IVerbumDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteContactGroupCommand request, CancellationToken cancellationToken) {
            
            var entity = await _dbContext.userContactGroups.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContactGroup), request.Id);
            }

            var userContacts = await (from contact in _dbContext.UserContacts
                                      where contact.GroupId == entity.Id
                                      select contact).ToListAsync();

            if (userContacts != null) {
                
                var generalGroup = await _dbContext.userContactGroups.FirstOrDefaultAsync(g => g.GroupName == "General", cancellationToken);
                
                if (generalGroup == null) {
                    throw new NotFoundException(nameof(ContactGroup), "General");
                }

                foreach (var contact in userContacts) {
                    contact.GroupId = generalGroup.Id;
                }
                
            }

            _dbContext.userContactGroups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;    
        }
    }
}
