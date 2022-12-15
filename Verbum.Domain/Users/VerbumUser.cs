using Verbum.Domain.MessagesDb;
using Verbum.Domain.Stikers;
using Verbum.Domain.Users;

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
        public bool IsOnline { get; set; }
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }    

        public UserDetails? userDetails { get; set; }
        public virtual ICollection<UserContact>? Contacts { get; set; }
        public virtual ICollection<Messages>? Messages { get; set; }
        public virtual ICollection<UserBlackList>? UserBlackLists { get; set; }
        public ICollection<ContactGroup>? ContactGroups { get; set; }
        public ICollection<StickersGroup>? stickersGroups { get; set; }
        public ICollection<FileMessage>? fileMessages { get; set; }
        //public ICollection<Group>? groups { get; set; }
    }
}
