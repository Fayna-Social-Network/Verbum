using MediatR; 

namespace Verbum.Application.UserGrops.GroupMessage.Queries.GetGroupMessagesByTheme
{
    public class GetGroupMessagesByThemeQuery : IRequest<GetGroupMessagesVm>
    {
        public Guid GroupThemeId { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
