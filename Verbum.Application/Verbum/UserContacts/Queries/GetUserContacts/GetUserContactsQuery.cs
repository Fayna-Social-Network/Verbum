using MediatR;

namespace Verbum.Application.Verbum.UserContacts.Queries.GetUserContacts
{
    public class GetUserContactsQuery :IRequest<UserContactsVm>
    {
        public Guid UserId { get; set; }
    }
}
