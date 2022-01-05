namespace Verbum.WebApi.Models
{
    public class SendClientMessage
    {
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public DateTime Timestamp { get; set; }
        public bool isRead { get; set; }
        public Guid UserId { get; set; }
    } 
}



