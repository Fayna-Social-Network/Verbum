using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Users.Queries.GetAllUserQuery
{
    public class GetAllUserQueryHandler :IRequestHandler<GetAllUsersQuery, UsersListVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UsersListVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.Users
                .ProjectTo<UsersListLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new UsersListVm { Users = query };
        }

       
    }
}
