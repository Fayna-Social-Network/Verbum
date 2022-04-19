using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Verbum.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Verbum.Application.Common.Exceptions;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Queries.GetAllStickersGroups
{
    public class GetAllStickerGroupsQueryHandler :IRequestHandler<GetAllStickerGroupsQuery, StickerGroupsVm>
    {
        private readonly IVerbumDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllStickerGroupsQueryHandler(IVerbumDbContext verbumDb, IMapper mapper) =>
            (_dbContext, _mapper) = (verbumDb, mapper);

        public async Task<StickerGroupsVm> Handle(GetAllStickerGroupsQuery request, CancellationToken cancellationToken) {
            var query = await _dbContext.stickersGroups.Include(s => s.Stickers)
                .ProjectTo<StickerGroupsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (query == null)
            {
                throw new NotFoundException(nameof(StickersGroup), "empty");
            }

            return new StickerGroupsVm { stickerGroups = query };
        } 
    }
}
