using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class UserBlackList
    {
        public Guid Id { get; set; }
        public Guid Contact { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
