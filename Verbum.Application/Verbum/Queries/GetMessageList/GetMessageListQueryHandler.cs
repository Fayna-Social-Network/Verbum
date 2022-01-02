using AutoMapper;
using MediatR;
using Verbum.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Verbum.Application.Verbum.Queries.GetMessageList
{
    public class GetMessageListQueryHandler 
        : IRequestHandler<GetMessageListQuery, MessageListVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<MessageListVm> Handle(GetMessageListQuery request,
            CancellationToken cancellationToken)
        {
            var messagesQuery = await _dbContext.Messages
               .Where(mess => mess.UserId == request.UserId)
               .ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new MessageListVm { Messages = messagesQuery };
        }
    }
}
