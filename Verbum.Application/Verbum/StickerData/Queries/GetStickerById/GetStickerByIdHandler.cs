using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickerById
{
    public class GetStickerByIdHandler :IRequestHandler<GetStickerByIdQuery, StickerDto>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStickerByIdHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<StickerDto> Handle(GetStickerByIdQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.Stickers.FirstOrDefaultAsync(s => s.Id == request.stickerId);

            if (query == null) {
                throw new NotFoundException(nameof(Sticker), request.stickerId);
            }

            return _mapper.Map<StickerDto>(query);
        }
    }
}
