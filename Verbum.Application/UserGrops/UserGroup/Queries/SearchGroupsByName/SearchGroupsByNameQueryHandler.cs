using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups;
using Verbum.Application.UserGrops.UserGroup.Queries.GetUserGroups;

namespace Verbum.Application.UserGrops.UserGroup.Queries.SearchGroupsByName
{
    public class SearchGroupsByNameQueryHandler : IRequestHandler<SearchGroupsByNameQuery, GetAllGroupsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchGroupsByNameQueryHandler(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllGroupsVm> Handle(SearchGroupsByNameQuery query, CancellationToken cancellationToken)
        {
            var groups = await _dbContext.groups.Where(g => g.GroupName!.StartsWith(query.GroupName!)).Include(g => g.groupsThemes)
                .ProjectTo<GroupsAllListLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new GetAllGroupsVm { Groups = groups };
        }
    }
}
