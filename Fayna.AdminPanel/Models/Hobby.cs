using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class Hobby
    {
        public Hobby()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public Guid Id { get; set; }
        public string? HobbyName { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
