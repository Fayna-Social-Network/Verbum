namespace Verbum.Domain.Users.Details
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        public string? Operator { get; set; }
        public long Number { get; set; }

        public Guid UserDetailsId { get; set; }
        public UserDetails? userDetails { get; set; }
    }
}
