
namespace Verbum.Application.Hubs.dtos
{
    public class CallToUserDto
    {
        public Guid UserToCall { get; set; }
        public string? SignalData { get; set; }
    }
}
