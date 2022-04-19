using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, VerbumUser>
    {
        private readonly IVerbumDbContext _dbContext;

        public GetUserByIdQueryHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<VerbumUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null) {
                throw new NotFoundException(nameof(VerbumUser), request.UserId);
            }

            return user;
        }
    }
}
