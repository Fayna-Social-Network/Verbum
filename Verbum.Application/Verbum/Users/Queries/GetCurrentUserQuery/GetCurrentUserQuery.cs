using MediatR;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetCurrentUserQuery
{
    public class GetCurrentUserQuery :IRequest<CurrentUserVm>
    {
        public string? NickName { get; set; }
    }
}
