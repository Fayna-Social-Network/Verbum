using Verbum.Domain.UserFilesTable;

namespace Verbum.Domain.Common
{
    public class VideoMessage
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
       
        public List<UserFile>? userFiles { get; set; }
    }
}
