using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.ChatOnes;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class GetAudioMessageQueryHandler: IRequestHandler<GetAudioMessageQuery, AudioMessageVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAudioMessageQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<AudioMessageVm> Handle(GetAudioMessageQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.chatAudioMessages
                .Include(f => f.userFiles).FirstOrDefaultAsync(a => a.ChatMessageId == request.MessageId);

            if (query == null)
            {
                throw new NotFoundException(nameof(ChatAudioMessage), request.MessageId);
            }

            return _mapper.Map<AudioMessageVm>(query);

        }
    }
}
