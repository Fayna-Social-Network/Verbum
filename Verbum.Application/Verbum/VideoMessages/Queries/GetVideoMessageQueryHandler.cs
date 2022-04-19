using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.VideoMessages.Queries
{
    public class GetVideoMessageQueryHandler : IRequestHandler<GetVideoMessageQuery, videoMessageVm>
    {

        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVideoMessageQueryHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<videoMessageVm> Handle(GetVideoMessageQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.videoMessages.SingleAsync(v => v.MessageId == request.MessageId);

            if (query == null) {
                throw new NotFoundException(nameof(VideoMessage), request.MessageId);
            }

            return _mapper.Map<videoMessageVm>(query);

        }
    }
}
