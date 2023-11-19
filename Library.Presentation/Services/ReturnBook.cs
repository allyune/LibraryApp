using System;
using Library.BusinessLogic.Exceptions;
using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
	public class ReturnBook : IReturnBook, ICommand
    {
        private readonly IBookService _bookService;
        public string Title = "Return a book";
        public ReturnBook(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter book Id");
            string bookInput = PresentationUtils.GetInput();

            if (!Guid.TryParse(bookInput, out Guid bookId))
            {
                Console.WriteLine("Not valid book Id");
                return;
            }

            string userInput = PresentationUtils.GetInput();
            if (!Guid.TryParse(userInput, out Guid userId))
            {
                Console.WriteLine("Not valid book Id");
                return;
            }
            try
            {
                _bookService.ReturnBook(bookId, userId);
            }
            catch (BookDoesNotExistException)
            {
                Console.WriteLine("Book with such Id does not exist");
            }
            catch (BookNotBorrowedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string getTitle()
        {
            return Title;
        }
    }
}

