using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;

namespace Verbum.Application.Verbum.Message.Queries.GetChatMessages
{
    public class GetChatMessagesQueryHandler : IRequestHandler<GetChatMessagesQuery, ChatMessagesVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetChatMessagesQueryHandler(IVerbumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ChatMessagesVm> Handle(GetChatMessagesQuery query, CancellationToken cancellationToken) 
        {
            var result = await _dbContext.chatMessages.Where(m => m.ChatId == query.ChatId)
                .ProjectTo<ChatMessagesLookupDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new ChatMessagesVm { ChatMessages = result };
        
        }
    }
}
