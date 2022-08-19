using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class FileMessage
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public Guid MessageId { get; set; }
        public Guid? UserId { get; set; }

        public virtual Message Message { get; set; } = null!;
        public virtual User? User { get; set; }
    }
}
