
namespace Verbum.Domain
{
    public class VerbumUser
    {
        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsOnline { get; set; } = false;
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }    

        public List<UserContact>? Contacts { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
