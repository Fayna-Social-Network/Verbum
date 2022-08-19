using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class UserContact
    {
        public Guid Id { get; set; }
        public Guid Contact { get; set; }
        public string? Name { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }

        public virtual User ContactNavigation { get; set; } = null!;
        public virtual ContactGroup Group { get; set; } = null!;
    }
}
