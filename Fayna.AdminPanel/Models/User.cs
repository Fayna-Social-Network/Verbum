using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class User
    {
        public User()
        {
            FileMessages = new HashSet<FileMessage>();
            Messages = new HashSet<Message>();
            UserBlackLists = new HashSet<UserBlackList>();
            UserContacts = new HashSet<UserContact>();
            ContactGroups = new HashSet<ContactGroup>();
            StickersGroups = new HashSet<StickersGroup>();
        }

        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public bool IsOnline { get; set; }
        public string? HubConnectionId { get; set; }
        public DateTime UserRegistrationDate { get; set; }

        public virtual UserDetail UserDetail { get; set; } = null!;
        public virtual ICollection<FileMessage> FileMessages { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<UserBlackList> UserBlackLists { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }

        public virtual ICollection<ContactGroup> ContactGroups { get; set; }
        public virtual ICollection<StickersGroup> StickersGroups { get; set; }
    }
}
