using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Microsoft.Extensions.Hosting;

namespace Verbum.Application.Verbum.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler :IRequestHandler<UpdateUserCommand>
    {
        IVerbumDbContext _dbContext;
       

        public UpdateUserCommandHandler(IVerbumDbContext dbContext)
            => (_dbContext) = (dbContext);


        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
             var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.Id, cancellationToken);

            if (entity == null) {
                throw new NotFoundException(nameof(VerbumUser), request.Id);
            }

           
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Avatar = request.Avatar;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
