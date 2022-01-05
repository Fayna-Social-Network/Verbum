
namespace Verbum.Domain
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public List<VerbumUser>? Users { get; set; }
    }
}
