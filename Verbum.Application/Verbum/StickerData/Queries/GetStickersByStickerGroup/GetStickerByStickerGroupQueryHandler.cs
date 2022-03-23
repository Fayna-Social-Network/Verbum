using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Common.Exceptions;
using Verbum.Application.Interfaces;
using Verbum.Domain.Stikers;
using AutoMapper.QueryableExtensions;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup
{
    public class GetStickerByStickerGroupQueryHandler :IRequestHandler<GetStickerByStickerGroupQuery, StikersVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStickerByStickerGroupQueryHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<StikersVm> Handle(GetStickerByStickerGroupQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.Stickers.Where(s => s.StickerGroupId == request.StickersGroupId)
                .ProjectTo<StickersLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (query == null) {
                throw new NotFoundException(nameof(StickersGroup), request.StickersGroupId);
            }

            return new StikersVm { stickers = query };
        } 

    }
}
