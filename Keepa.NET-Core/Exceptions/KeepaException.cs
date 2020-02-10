 using Keepa.NET_Core.Contracts;
using System;

namespace Keepa.NET_Core.Exceptions
{
    public class KeepaException : Exception
    {
        public Error Errors { get; protected set; }
        public KeepaException(Error errors) : base(errors.Message)
        {
            Errors = errors;
        }

        public KeepaException(string message) : base(message) { }
    }
}
