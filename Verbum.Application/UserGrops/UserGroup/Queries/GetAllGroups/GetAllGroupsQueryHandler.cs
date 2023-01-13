using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQuery, GetAllGroupsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllGroupsQueryHandler(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetAllGroupsVm> Handle(GetAllGroupsQuery query, CancellationToken cancellationToken) 
        {
            var groups = await _dbContext.groups.Include(g => g.groupsThemes)
                .ProjectTo<GroupsAllListLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new GetAllGroupsVm { Groups = groups };
        }
    }
}
