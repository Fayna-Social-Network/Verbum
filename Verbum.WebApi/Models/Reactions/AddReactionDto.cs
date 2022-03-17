namespace Verbum.WebApi.Models.Reactions
{
    public class AddReactionDto
    {
        public Guid MessageId { get; set; }
        public string? ReactionName { get; set; }

    }
}
