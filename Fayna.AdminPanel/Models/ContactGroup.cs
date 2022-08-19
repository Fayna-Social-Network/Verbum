using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class ContactGroup
    {
        public ContactGroup()
        {
            UserContacts = new HashSet<UserContact>();
            VerbumUsers = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string? GroupName { get; set; }

        public virtual ICollection<UserContact> UserContacts { get; set; }

        public virtual ICollection<User> VerbumUsers { get; set; }
    }
}
