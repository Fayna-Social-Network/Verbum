using MediatR;

namespace Verbum.Application.Verbum.StickerData.Commands.DeleteStickersGroupFromUser
{
    public class DeleteStickersGroupFromUserCommand :IRequest
    {
        public Guid StickerGroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
