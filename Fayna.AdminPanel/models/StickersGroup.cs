﻿using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class StickersGroup
    {
        public StickersGroup()
        {
            Stickers = new HashSet<Sticker>();
            VerbumUsers = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Sticker> Stickers { get; set; }

        public virtual ICollection<User> VerbumUsers { get; set; }
    }
}
