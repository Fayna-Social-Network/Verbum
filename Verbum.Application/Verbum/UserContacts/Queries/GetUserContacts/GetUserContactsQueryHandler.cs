using AutoMapper;
using MediatR;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Common.Exceptions;
using Verbum.Domain;

namespace Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts
{
    public class GetUserContactsQueryHandler :IRequestHandler<GetUserContactsQuery, UserContactsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserContactsQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserContactsVm> Handle(GetUserContactsQuery request, CancellationToken cancellationToken) {
           
            
            var query = await _dbContext.UserContacts.Where(u => u.UserId == request.UserId)
                .Include(p => p.User)
                .Include(g => g.Group)
                .ProjectTo<UserContactlookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                     

            if (query == null)
            {
                throw new NotFoundException(nameof(UserContact), request.UserId);
            }

           
            return new UserContactsVm { UserContacts = query };
        }
    }
}
