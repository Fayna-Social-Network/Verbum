using Verbum.Domain.MessagesDb;

namespace Verbum.Domain
{
    public class VerbumUser
    {
        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public bool IsOnline { get; set; } = false;
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }    

        public virtual ICollection<UserContact>? Contacts { get; set; }
        public virtual ICollection<Messages>? Messages { get; set; }
        public virtual ICollection<UserBlackList>? UserBlackLists { get; set; }
    }
}
