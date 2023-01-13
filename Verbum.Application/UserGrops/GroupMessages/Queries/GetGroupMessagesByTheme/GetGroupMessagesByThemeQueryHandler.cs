using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Application.Verbum.Repositories;

namespace Verbum.Application.UserGrops.GroupMessage.Queries.GetGroupMessagesByTheme
{
    public class GetGroupMessagesByThemeQueryHandler :IRequestHandler<GetGroupMessagesByThemeQuery, GetGroupMessagesVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonRepository _common;

        public GetGroupMessagesByThemeQueryHandler(IVerbumDbContext dbContext, IMapper mapper, CommonRepository common)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _common = common;
        }

        public async Task<GetGroupMessagesVm> Handle(GetGroupMessagesByThemeQuery query, CancellationToken cancellationToken) 
        {
            var group = await _dbContext.groups.Include(g => g.users).FirstOrDefaultAsync(g => g.id == query.GroupId);

            List<GetGroupMessageLookupDto> dto;

            if(group == null) 
            {
                throw new NotFoundException(nameof(group), query.GroupId);
            }

            if(group.isGroupClosed) 
            {
                if(group.UserId == query.UserId) 
                {
                    dto = await GetGroupMessages(query.GroupThemeId);

                } else 
                {
                    if(_common.IsTheUserInGroup(group.users!, query.UserId)) 
                    {
                        dto = await GetGroupMessages(query.GroupThemeId);
                    } else 
                    {
                        throw new GroupIsClosedException();
                    }
                }
            }

            dto = await GetGroupMessages(query.GroupThemeId);

            return new GetGroupMessagesVm { groupMessages = dto };
        }
        
        private async Task<List<GetGroupMessageLookupDto>> GetGroupMessages(Guid groupThemeId) 
        {
            var messages = await _dbContext.groupMessages
                .Where(t => t.GroupThemeId == groupThemeId)
                .Include(c => c.Comments).ProjectTo<GetGroupMessageLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return messages;
        }
    }
}
