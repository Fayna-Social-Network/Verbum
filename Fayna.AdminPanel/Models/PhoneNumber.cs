using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class PhoneNumber
    {
        public Guid Id { get; set; }
        public string? Operator { get; set; }
        public long Number { get; set; }
        public Guid UserDetailsId { get; set; }

        public virtual UserDetail UserDetails { get; set; } = null!;
    }
}
