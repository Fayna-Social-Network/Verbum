
namespace Verbum.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? NickName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public List<UserContact>? Contacts { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
    }
}
