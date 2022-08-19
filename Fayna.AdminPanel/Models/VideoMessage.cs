using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class VideoMessage
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = null!;
        public string Title { get; set; } = null!;
        public Guid MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
    }
}
