using AutoMapper;
using Verbum.Domain.Stikers;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup
{
    public class StikersVm
    {
        public List<StickersLookupDto>? stickers { get; set; }
    }
}