namespace Verbum.WebApi.Models
{
    public class GetCorrespondenceDto
    {
        public Guid Owner { get; set; }
        public Guid WithWho { get; set; }
    }
}
