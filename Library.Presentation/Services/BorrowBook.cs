using System;
using System.Reflection;
using Library.BusinessLogic.Exceptions;
using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
    public class BorrowBook : IBorrowBook, ICommand
    {
        private readonly IBookService _bookService;
        public string Title = "Borrow a book";

        public BorrowBook(IBookService bookService)
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

            Console.WriteLine("Enter user id");
            string userInput = PresentationUtils.GetInput();
            if (!Guid.TryParse(userInput, out Guid userId))
            {
                Console.WriteLine("Not valid book Id");
                return;
            }
            try
            {
                _bookService.BorrowBook(bookId, userId);
            }
            catch (BookDoesNotExistException)
            {
                Console.WriteLine("Book with such Id does not exist");
            }
            catch (BookAlreadyBorrowedException)
            {
                Console.WriteLine("This book is already borrowed");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while fetching book info");
            }
        }

        public string getTitle()
        {
            return Title;
        }
    }
}

