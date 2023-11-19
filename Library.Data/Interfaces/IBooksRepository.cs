using System;
using Library.Data.Entities;

namespace Library.Data.Interfaces
{
    public interface IBooksRepository
    {
        public List<Book> GetAllBooks();
        public Guid AddBook(Book book);
        public Book GetBookById(Guid id);
    }
}

