using MediatR;


namespace Verbum.Application.Verbum.ImageMessages.Queries.GetMessageImages
{
    public class GetMessageImagesQuery :IRequest<MessageImagesVm>
    {
        public Guid MessageId { get; set; }
    }
}
