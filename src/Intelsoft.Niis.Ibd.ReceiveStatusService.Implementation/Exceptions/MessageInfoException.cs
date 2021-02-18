using System;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Implementation.Exceptions
{
    public class MessageInfoException : Exception
    {
        public MessageInfoException(string message) : base(message)
        {
        }
    }
}