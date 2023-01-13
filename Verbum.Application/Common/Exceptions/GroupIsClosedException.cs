
namespace Verbum.Application.Common.Exceptions
{
    public class GroupIsClosedException : Exception
    {
        public GroupIsClosedException() 
            :base("Group is Closed") { }
    }
}
