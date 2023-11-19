using System;
using Library.Data.Entities;
using Library.Data.Interfaces;

namespace Library.Data.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> bookStorage = new List<Book>()
        {
            new Book(
                "Clean Code",
                new Author("Robert C.", "Martin"),
                new Category("Programming"),
                "9780132350884",
                2008,
                new Language("ENG", "English"))
        };

        public List<Book> GetAllBooks()
        {
            return bookStorage;
        }

        public Book GetBookById(Guid id)
        {
            var book = bookStorage.FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                throw new ArgumentNullException("Book does not exist");
            }
            return book;
        }

        public Guid AddBook(Book book)
        {
            bookStorage.Add(book);
            return book.Id;
        }
    }
}

