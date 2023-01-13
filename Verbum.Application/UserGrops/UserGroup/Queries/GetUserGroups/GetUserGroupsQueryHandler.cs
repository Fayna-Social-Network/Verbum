using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetUserGroups
{
    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQuery, GetAllGroupsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserGroupsQueryHandler(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllGroupsVm> Handle(GetUserGroupsQuery query, CancellationToken cancellationToken)
        {
            var groups = await _dbContext.groups.Where(g => g.UserId == query.UserId).Include(g => g.groupsThemes)
                .ProjectTo<GroupsAllListLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new GetAllGroupsVm { Groups = groups };
        }
    }
}
