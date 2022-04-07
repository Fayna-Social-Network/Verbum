using MediatR;
using Verbum.Domain;

namespace Verbum.Application.Verbum.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<VerbumUser>
    {
        public Guid UserId { get; set; }
    }
}
