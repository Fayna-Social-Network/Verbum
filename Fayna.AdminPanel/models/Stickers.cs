namespace Fayna.AdminPanel.models
{
    internal class Stickers
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;

        public Guid StickerGroupId { get; set; }
        public virtual StickersGroup? stickersGroup { get; set; }
    }
}
