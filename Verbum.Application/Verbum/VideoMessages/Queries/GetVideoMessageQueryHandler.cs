using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.ChatOnes;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class GetVideoMessageQueryHandler : IRequestHandler<GetVideoMessageQuery, videoMessageVm>
    {

        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVideoMessageQueryHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<videoMessageVm> Handle(GetVideoMessageQuery request, CancellationToken cancellationToken) {

            var query = await _dbContext.chatVideoMessages.Include(v => v.userFiles).FirstOrDefaultAsync(m => m.ChatMessageId == request.MessageId);

            if (query == null) {

                throw new NotFoundException(nameof(ChatVideoMessage), request.MessageId);

            }

            return _mapper.Map<videoMessageVm>(query);

        }
    }
}
