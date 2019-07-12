using Keepa.NET_Core.Entities;
using System;

namespace Keepa.NET_Core.Exceptions
{
    public class KeepaException : Exception
    {
        public string Details { get; set; }

        public KeepaException(Error error) : base (error.Message, new Exception(error.Type))
        {
            Details = error.Details;
        }
    }
}
