using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        public Guid ImageAlbumId { get; set; }

        public virtual ImageAlbum ImageAlbum { get; set; } = null!;
    }
}
