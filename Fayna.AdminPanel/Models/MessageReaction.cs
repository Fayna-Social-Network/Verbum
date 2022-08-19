using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class MessageReaction
    {
        public Guid Id { get; set; }
        public string? ReactionName { get; set; }
        public int ReactionCount { get; set; }
        public Guid UserId { get; set; }
        public Guid MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
    }
}
