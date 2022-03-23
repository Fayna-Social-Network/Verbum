using MediatR;

namespace Verbum.Application.Verbum.StickerData.Commands.AddStickerGroupToUser
{
    public class AddStickerGroupToUserCommand :IRequest
    {
        public Guid StickerGroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
