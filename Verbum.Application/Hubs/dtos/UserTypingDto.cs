
namespace Verbum.Application.Hubs.dtos
{
    public class UserTypingDto
    {
        public Guid User { get; set; }
        public Guid FromWho { get; set; }
    }
}
