using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using AutoMapper;
using Verbum.Application.Common.Exceptions;
using Verbum.Domain.ChatOnes;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class GetMessageImagesQueryHandler : IRequestHandler<GetMessageImagesQuery, MessageImagesVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMessageImagesQueryHandler(IVerbumDbContext verbumDbContext, IMapper mapper) =>
           (_dbContext, _mapper)  = (verbumDbContext, mapper);

        public async Task<MessageImagesVm> Handle(GetMessageImagesQuery request, CancellationToken cancellationToken) {
            
            var query = await _dbContext.chatImageMessages
                .Include(im => im.userFiles)
                .FirstOrDefaultAsync(i => i.ChatMessageId == request.MessageId, cancellationToken);

            if(query == null) 
            {
                throw new NotFoundException(nameof(ChatImageMessage), request.MessageId);
            }

            return _mapper.Map<MessageImagesVm>(query);
        } 
    }
}
