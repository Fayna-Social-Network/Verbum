using MediatR;
using AutoMapper;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Verbum.Application.Verbum.Users.Queries.GetUsersByCountAndPage
{
    public class GetUsersByCountAndPageQueryHandler : IRequestHandler<GetUsersByCountAndPageQuery, UsersListVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersByCountAndPageQueryHandler(IVerbumDbContext verbumDbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDbContext, mapper);


        public async Task<UsersListVm> Handle(GetUsersByCountAndPageQuery request, CancellationToken cancellationToken) {

            if (request.Page == 0) {
                request.Page = 1;
            }

            var skiper = (request.Page - 1) * request.Count;


            var query = await _dbContext.Users
                .Skip(skiper)
                .Take(request.Count)
                .OrderBy(u => u.NickName)
                .ProjectTo<UsersListLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new UsersListVm { Users = query };
        }
    }
}
