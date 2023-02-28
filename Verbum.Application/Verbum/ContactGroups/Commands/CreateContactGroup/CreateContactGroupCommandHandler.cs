using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.ContactGroups.Commands.CreateContactGroup
{
    public class CreateContactGroupCommandHandler :IRequestHandler<CreateContactGroupCommand, Guid>
    {
        private readonly IVerbumDbContext _dbContext;

        public CreateContactGroupCommandHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Guid> Handle(CreateContactGroupCommand request, CancellationToken cancellationToken) {

            var user = await _dbContext.Users.Include(u => u.ContactGroups).FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            var contactGroup = new ContactGroup
            {
                Id = Guid.NewGuid(),
                GroupName = request.GroupName
            };

            await _dbContext.userContactGroups.AddAsync(contactGroup);

         
            user.ContactGroups?.Add(contactGroup);


            await _dbContext.SaveChangesAsync(cancellationToken);

            return contactGroup.Id;
           
            
        }
    }
}
