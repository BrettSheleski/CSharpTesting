using System;

namespace Sheleski.Testing
{
    public class ExpectedExceptionNotThrownException : Exception
    {
        public ExpectedExceptionNotThrownException()
        {
        }

        public ExpectedExceptionNotThrownException(string message) : base(message)
        {
        }

        public ExpectedExceptionNotThrownException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}