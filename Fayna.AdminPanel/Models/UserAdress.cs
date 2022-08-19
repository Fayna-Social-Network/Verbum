using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class UserAdress
    {
        public Guid Id { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? House { get; set; }
        public string? Apartment { get; set; }
        public int ZipCode { get; set; }
        public Guid UserDetailsId { get; set; }

        public virtual UserDetail UserDetails { get; set; } = null!;
    }
}
