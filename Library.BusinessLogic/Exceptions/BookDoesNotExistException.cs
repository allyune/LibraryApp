using System;
namespace Library.BusinessLogic.Exceptions
{
	public class BookDoesNotExistException : Exception
    {
        public BookDoesNotExistException() { }

        public BookDoesNotExistException(string message)
            : base(message) { }

        public BookDoesNotExistException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}
