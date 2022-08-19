using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class SocialNetwork
    {
        public SocialNetwork()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
