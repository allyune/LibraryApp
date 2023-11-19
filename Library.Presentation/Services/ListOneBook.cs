using System;
using Library.BusinessLogic.Exceptions;
using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
	public class ListOneBook : IListOneBook, ICommand
    {
        private readonly IBookService _bookService;
        public string Title = "Find a book";

        public ListOneBook(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter book Id");
            string userInput = PresentationUtils.GetInput();
            bool isValidGuid = Guid.TryParse(userInput, out Guid bookId);
            if (!isValidGuid)
                Console.WriteLine("Not valid book Id");
            else
            {
                try
                {
                    var book = _bookService.GetBookById(bookId);
                    Console.WriteLine(" ");
                    Console.WriteLine("Book info:");
                    PresentationUtils.PrintBookInfo(book);
                }
                catch (BookDoesNotExistException)
                {
                    Console.WriteLine("Book with such Id does not exist");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error while fetching book info");
                }
            }
        }
        public string getTitle()
        {
            return Title;
        }
    }
}

