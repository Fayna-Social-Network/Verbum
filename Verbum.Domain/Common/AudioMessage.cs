using Verbum.Domain.UserFilesTable;

namespace Verbum.Domain.Common
{
    public class AudioMessage
    {
        public Guid Id { get; set; }
       
        public List<UserFile>? userFiles { get; set; }
       
    }
}
