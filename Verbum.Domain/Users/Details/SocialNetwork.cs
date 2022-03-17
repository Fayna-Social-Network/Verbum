
namespace Verbum.Domain.Users.Details
{
    public class SocialNetwork
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public ICollection<UserDetails>? userDetails { get; set; }
    }
}
