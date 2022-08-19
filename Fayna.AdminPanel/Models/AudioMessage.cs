using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class AudioMessage
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        public Guid MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
    }
}
