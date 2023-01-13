using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain;

namespace Verbum.Application.UserGrops.UserGroup.Queries.GetGroupById
{
    public class GetGroupByIdQueryHandle : IRequestHandler<GetGroupByIdQuery, GetGroupByIdVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupByIdQueryHandle(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetGroupByIdVm> Handle(GetGroupByIdQuery query, CancellationToken cancellationToken)
        {
            var group = await _dbContext.groups.Include(g => g.groupsThemes).FirstOrDefaultAsync(g => g.id == query.GroupId);

            if (group == null)
            {
                throw new NotFoundException(nameof(Group), query.GroupId);
            }

            return _mapper.Map<GetGroupByIdVm>(group);
        }
    }
}
