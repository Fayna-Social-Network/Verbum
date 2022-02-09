using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class GetMessageImagesQueryHandler : IRequestHandler<GetMessageImagesQuery, ImageAlbum>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMessageImagesQueryHandler(IVerbumDbContext verbumDbContext, IMapper mapper) =>
           (_dbContext, _mapper)  = (verbumDbContext, mapper);

        public async Task<ImageAlbum> Handle(GetMessageImagesQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.ImageAlbums.Include(im => im.ImageMessages)
                .SingleAsync(i => i.MessageId == request.MessageId, cancellationToken);

            return query;
        } 
    }
}
