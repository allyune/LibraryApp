using System;
using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
	public class ListBorrowedBooks : ICommand, IListBorrowedBooks
    {
        private readonly IBookService _bookService;

        public string Title = "List borrowed books";
        public ListBorrowedBooks(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter user id");
            string userInput = PresentationUtils.GetInput();
            if (!Guid.TryParse(userInput, out Guid userId))
            {
                Console.WriteLine("Not valid book Id");
                return;
            }
            var books = _bookService.GetBorrowedBookByUser(userId);
            if (books is null || books.Count() == 0)
                Console.WriteLine("You have not borrowed any books");
            Console.WriteLine(" ");
            Console.WriteLine("Books you have borrowed:");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name} by {book.AuthorName} {book.AuthorSurname}");
            }
        }
        public string getTitle()
        {
            return Title;
        }
    }
}

