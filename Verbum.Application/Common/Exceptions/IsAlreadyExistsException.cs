

namespace Verbum.Application.Common.Exceptions
{
    public class IsAlreadyExistsException : Exception
    {
        public IsAlreadyExistsException(string message)
            : base(message) { }
    }
}
