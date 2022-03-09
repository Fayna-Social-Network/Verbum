
namespace Verbum.Domain.Users
{
    public class ContactGroup
    {
        public Guid Id { get; set; }
        public string? GroupName { get; set; }

        public ICollection<UserContact>? userContacts { get; set; }
        public ICollection<VerbumUser>? verbumUsers { get; set; }
    }
}
