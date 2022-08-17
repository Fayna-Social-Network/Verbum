
namespace Fayna.AdminPanel.models
{
    internal class StickersGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public ICollection<Stickers>? Stickers { get; set; }
    }
}
