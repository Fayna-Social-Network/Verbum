using System;
using System.Collections.Generic;

namespace Fayna.AdminPanel.Models
{
    public partial class Sticker
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public Guid StickerGroupId { get; set; }
        public Guid? StickersGroupId { get; set; }

        public virtual StickersGroup? StickersGroup { get; set; }
    }
}
