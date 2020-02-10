using Keepa.NET_Core.Contracts;

namespace Keepa.NET_Core.Exceptions
{
    public class NotEnoughTokensException : KeepaException
    {
        public NotEnoughTokensException(Error errors) : base(errors.Message)
        {
            Errors = errors;
        }
    }
}
