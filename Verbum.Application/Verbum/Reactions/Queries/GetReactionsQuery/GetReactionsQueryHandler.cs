using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Verbum.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Verbum.Application.Verbum.Reactions.Queries.GetReactionsQuery
{
    public class GetReactionsQueryHandler :IRequestHandler<GetReactionsQuery, ReactionsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReactionsQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ReactionsVm> Handle(GetReactionsQuery request, CancellationToken cancellationToken) {
            var query = await (from reactions in _dbContext.MessageReactions
                               where reactions.MessageId == request.MessageId
                               select reactions)
                               .ProjectTo<ReactionLookupDto>(_mapper.ConfigurationProvider)
                               .ToListAsync();

            return new ReactionsVm { Reactions = query };
        }
    }
}
