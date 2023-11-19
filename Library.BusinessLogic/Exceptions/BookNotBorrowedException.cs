using System;
namespace Library.BusinessLogic.Exceptions
{
    public class BookNotBorrowedException : Exception
    {
        public BookNotBorrowedException() { }

        public BookNotBorrowedException(string message)
            : base(message) { }

        public BookNotBorrowedException(string message, Exception innerException)
            : base(message, innerException) { }

    }
}