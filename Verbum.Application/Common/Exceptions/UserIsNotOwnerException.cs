
namespace Verbum.Application.Common.Exceptions
{
    public class UserIsNotOwnerException : Exception
    {
        public UserIsNotOwnerException()
            :base("The user does not own this group") { }
    }
}
