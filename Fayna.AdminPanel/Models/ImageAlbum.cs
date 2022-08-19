using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class ImageAlbum
    {
        public ImageAlbum()
        {
            Images = new HashSet<Image>();
        }

        public Guid Id { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public Guid MessageId { get; set; }

        public virtual Message Message { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; }
    }
}
