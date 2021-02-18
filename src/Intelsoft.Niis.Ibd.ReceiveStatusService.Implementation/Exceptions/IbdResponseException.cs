using System;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation.Exceptions
{
    public class IbdResponseException : Exception
    {
        public IbdResponseException(string message) : base(message)
        {
        }
    }
}