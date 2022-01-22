using MediatR;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;

namespace Verbum.Application.Verbum.Users.Queries.GetUsersByCountAndPage
{
    public class GetUsersByCountAndPageQuery :IRequest<UsersListVm>
    {
        public int Count { get; set; }
        public int Page { get; set; }
    }
}
