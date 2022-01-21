using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;

namespace Verbum.Application.Verbum.Users.Queries.SearchUsersByNickName
{
    public class SearchUserByNickNameHandler : IRequestHandler<SearchUserByNickNameQuery, UsersListVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchUserByNickNameHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<UsersListVm> Handle(SearchUserByNickNameQuery request, CancellationToken cancellationToken) {
            var query = await (from user in _dbContext.Users
                                where user.NickName.StartsWith(request.Text)
                                orderby user.NickName descending
                                select user)
                                .ProjectTo<UsersListLookupDto>(_mapper.ConfigurationProvider)
                                .ToListAsync();

           
            return new UsersListVm { Users = query };

        }
    }
}
