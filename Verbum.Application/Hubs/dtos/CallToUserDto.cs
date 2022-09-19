
namespace Verbum.Application.Hubs.dtos
{
    public class CallToUserDto
    {
        public Guid UserToCall { get; set; }
        public string? SignalData { get; set; }
        public string? FromUserNickname { get; set; }
        public string? CallType { get; set; } 
    }
}
