
namespace Verbum.Domain
{
    public class UserBlackList
    {
        public Guid Id { get; set; }
        public Guid Contact { get; set; }

        public Guid UserId { get; set; }
        public virtual VerbumUser? BlockUser { get; set; }
    }
}
