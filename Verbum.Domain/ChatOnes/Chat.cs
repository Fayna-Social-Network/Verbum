
namespace Verbum.Domain.ChatOnes
{
    public class Chat
    {
        public Guid Id { get; set; }
             
        public List<ChatMessage>? chatMessages { get; set; }
        public List<UserContact>? userContacts { get; set; }
    }
}
