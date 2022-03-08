namespace Verbum.Domain
{
    public class UserContact
    {
        public Guid Id { get; set; }
        public Guid Contact { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }

        public Guid UserId { get; set; }
        public virtual VerbumUser? User{ get; set; } 
    }
}