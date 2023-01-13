using Verbum.Domain.UserFilesTable;

namespace Verbum.Domain.Common
{
    public class FileMessage
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        
        public List<UserFile>? userFiles { get; set; }
    }
}
