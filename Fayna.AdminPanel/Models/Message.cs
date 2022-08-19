using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class Message
    {
        public Message()
        {
            MessageReactions = new HashSet<MessageReaction>();
        }

        public Guid Id { get; set; }
        public string? Text { get; set; }
        public Guid Seller { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual AudioMessage AudioMessage { get; set; } = null!;
        public virtual FileMessage FileMessage { get; set; } = null!;
        public virtual ImageAlbum ImageAlbum { get; set; } = null!;
        public virtual VideoMessage VideoMessage { get; set; } = null!;
        public virtual ICollection<MessageReaction> MessageReactions { get; set; }
    }
}
