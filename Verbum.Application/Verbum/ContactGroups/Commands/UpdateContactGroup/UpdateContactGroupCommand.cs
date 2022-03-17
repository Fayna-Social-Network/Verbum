using MediatR;

namespace Verbum.Application.Verbum.ContactGroups.Commands.UpdateContactGroup
{
    public class UpdateContactGroupCommand :IRequest
    {
        public Guid GroupId { get; set; }
        public string? NewGroupName { get; set; }
    }
}
