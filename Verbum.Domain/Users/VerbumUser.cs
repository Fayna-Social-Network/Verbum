using Verbum.Domain.Stikers;
using Verbum.Domain.Notifications;
using Verbum.Domain.Users;
using Verbum.Domain.UserFilesTable;

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
        public virtual List<UserContact>? Contacts { get; set; }
        public virtual List<UserBlackList>? UserBlackLists { get; set; }
        public List<ContactGroup>? ContactGroups { get; set; }
        public List<StickersGroup>? stickersGroups { get; set; }
        public List<UserFile>? userFiles { get; set; }
        public List<Group>? groups { get; set; }
        public List<Notification>? notifications { get; set; }
    }
}
