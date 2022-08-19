using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
            Hobbies = new HashSet<Hobby>();
            SocialNetworks = new HashSet<SocialNetwork>();
        }

        public Guid Id { get; set; }
        public string? Profession { get; set; }
        public string? Tagline { get; set; }
        public string? About { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual UserAdress UserAdress { get; set; } = null!;
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public virtual ICollection<Hobby> Hobbies { get; set; }
        public virtual ICollection<SocialNetwork> SocialNetworks { get; set; }
    }
}
