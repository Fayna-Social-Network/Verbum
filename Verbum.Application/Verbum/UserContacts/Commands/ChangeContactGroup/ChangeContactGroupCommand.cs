using MediatR;

namespace Verbum.Application.Verbum.UserContacts.Commands.ChangeContactGroup
{
    public class ChangeContactGroupCommand : IRequest
    {
        public Guid ContactId { get; set; }
        public string? ContactName { get; set; }
        public Guid GroupId { get; set; }
    }
}
