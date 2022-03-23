using MediatR;

namespace Verbum.Application.Verbum.StickerData.Queries.GetStickerById
{
    public class GetStickerByIdQuery :IRequest<StickerDto>
    {
        public Guid stickerId { get; set; }
    }
}
