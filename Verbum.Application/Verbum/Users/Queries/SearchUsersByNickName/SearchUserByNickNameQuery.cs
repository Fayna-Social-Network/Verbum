using MediatR;
using Verbum.Application.Verbum.Users.Queries.GetAllUserQuery;

namespace Verbum.Application.Verbum.Users.Queries.SearchUsersByNickName
{
    public class SearchUserByNickNameQuery :IRequest<UsersListVm>
    {
        public string? Text { get; set; }
    }
}
