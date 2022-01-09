using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;
using Microsoft.Extensions.Hosting;

namespace Verbum.Application.Verbum.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler :IRequest<UpdateUserCommand>
    {
        IVerbumDbContext _dbContext;
        IHostEnvironment _appEnvironment;

        public UpdateUserCommandHandler(IVerbumDbContext dbContext, IHostEnvironment hostEnvironment)
            => (_dbContext, _appEnvironment) = (dbContext, hostEnvironment);


        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken) {
             var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.Id, cancellationToken);

            if (entity == null) {
                throw new NotFoundException(nameof(VerbumUser), request.Id);
            }

            if (request.formFile != null) {
                
                string path = "/Avatars/" + request.formFile.FileName;
               
                using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create))
                {
                    await request.formFile.CopyToAsync(fileStream);
                }
                entity.Avatar = path;
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
