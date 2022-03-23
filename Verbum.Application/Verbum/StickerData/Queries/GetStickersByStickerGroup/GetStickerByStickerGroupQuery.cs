using MediatR;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickersByStickerGroup
{
    public class GetStickerByStickerGroupQuery :IRequest<StikersVm>
    {
        public Guid StickersGroupId { get; set; }
    }
}
