
namespace Verbum.Domain
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public List<User>? Users { get; set; }
    }
}
