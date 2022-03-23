
namespace Verbum.Domain.Stikers
{
    public class StickersGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public ICollection<Sticker>? Stickers { get; set; }
        public virtual ICollection<VerbumUser>? verbumUsers { get; set; } 
    }
}
