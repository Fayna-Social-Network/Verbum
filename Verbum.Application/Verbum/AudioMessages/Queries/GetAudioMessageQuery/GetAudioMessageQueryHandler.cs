using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.AudioMessages.Queries.GetAudioMessageQuery
{
    public class GetAudioMessageQueryHandler: IRequestHandler<GetAudioMessageQuery, AudioMessageVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAudioMessageQueryHandler(IVerbumDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<AudioMessageVm> Handle(GetAudioMessageQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.audioMessages.SingleAsync(a => a.MessageId == request.MessageId, cancellationToken);

            if (query == null)
            {
                throw new NotFoundException(nameof(AudioMessage), request.MessageId);
            }

            return _mapper.Map<AudioMessageVm>(query);

        }
    }
}
