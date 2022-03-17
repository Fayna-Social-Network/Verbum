using MediatR;

namespace Verbum.Application.Verbum.ContactGroups.Commands.CreateContactGroup
{
    public class CreateContactGroupCommand : IRequest<Guid>
    {
        public string? GroupName { get; set; }
        public Guid UserId { get; set; }
    }
}
