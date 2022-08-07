using MediatR;

namespace Verbum.Application.Verbum.UserFilesAndMessages.Queries.GetFileMessageQuery
{
    public class GetFileMessageQuery :IRequest<FileMessageVm>
    {
        public Guid MessageId { get; set; }
    }
}
