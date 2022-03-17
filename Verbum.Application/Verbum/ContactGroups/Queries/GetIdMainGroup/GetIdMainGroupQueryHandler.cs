using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.Users;

namespace Verbum.Application.Verbum.ContactGroups.Queries.GetIdMainGroup
{
    public class GetIdMainGroupQueryHandler :IRequestHandler<GetIdMainGroupQuery, Guid>
    {
        private readonly IVerbumDbContext _dbContext;

        public GetIdMainGroupQueryHandler(IVerbumDbContext verbumDb) => _dbContext = verbumDb;

        public async Task<Guid> Handle(GetIdMainGroupQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.contactGroups.FirstOrDefaultAsync(g => g.GroupName == "General");

            if (query == null) {
                throw new NotFoundException(nameof(ContactGroup), "General");
            }

            return query.Id;
        }
    }
}
