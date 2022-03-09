
namespace Verbum.Domain.Users.Details
{
    public class Hobby
    {
        public Guid Id { get; set; }
        public string? HobbyName { get; set; }

        public ICollection<UserDetails>? userDetails { get; set; }
    }
}
