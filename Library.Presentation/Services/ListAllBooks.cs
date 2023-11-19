using System;
using System.Reflection;
using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
	public class ListAllBooks : IListAllBooks, ICommand
    {
        private readonly IBookService _bookService;

        public string Title = "List all books";
        public ListAllBooks(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void Execute()
        {
            var allBooks = _bookService.GetBooks();
            Console.WriteLine("");
            Console.WriteLine("List of books in the library:");
            foreach (var book in allBooks)
            {
                PresentationUtils.PrintBookInfo(book);
            }
        }
        public string getTitle()
        {
            return Title;
        }
    }
}

