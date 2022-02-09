using MediatR;
using Verbum.Domain.MessagesDb;

namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class GetMessageImagesQuery :IRequest<ImageAlbum>
    {
        public Guid MessageId { get; set; }
    }
}
