using MediatR;

namespace Verbum.Application.Verbum.ContactGroups.Commands.DeleteContactGroup
{
    public class DeleteContactGroupCommand :IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
