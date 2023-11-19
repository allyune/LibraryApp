using System;
using Library.BusinessLogic.DTOs;
using Library.BusinessLogic.Exceptions;
using Library.BusinessLogic.Interfaces;
using Library.Data.Entities;
using Library.Data.Interfaces;

namespace Library.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository bookRepository)
        {
            _booksRepository = bookRepository;

        }

        private BookDTO MapBook(Book book)
        {
            return new BookDTO(
                book.Id, book.Name,
                book.Author.Name,
                book.Author.Surname,
                book.Category.Name,
                book.ISBN,
                book.YearPublished,
                book.Language.Name, book.UserId);
        }


        private void EnsureBookNotBorrowed(Book book)
        {
            if (book.UserId is not null)
                throw new BookAlreadyBorrowedException();
        }

        public List<BookDTO> GetBooks()
        {
            return _booksRepository.GetAllBooks().Select(MapBook).ToList();
        }

        public BookDTO GetBookById(Guid id)
        {
            try
            {
                var book = _booksRepository.GetBookById(id);
                return MapBook(book);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"LOG: Book with id {id} does not exist");
                throw new BookDoesNotExistException();
            }
        }

        public void BorrowBook(Guid bookId, Guid userId)
        {
            try
            {
                var book = _booksRepository.GetBookById(bookId);
                EnsureBookNotBorrowed(book);
                book.UserId = userId;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"LOG: Book with id {bookId} does not exist");
                throw new BookDoesNotExistException(ex.Message, ex.InnerException);
            }
            catch (BookAlreadyBorrowedException)
            {
                Console.WriteLine($"LOG: Book with id {bookId} is already borrowed");
                throw;
            }
            
        }

        public List<BookDTO> GetBorrowedBookByUser(Guid usedId)
        {
           return _booksRepository
                    .GetAllBooks()
                    .Where(b => b.UserId == usedId)
                    .Select(MapBook)
                    .ToList();
        }

        public void ReturnBook(Guid bookId, Guid userId)
        {
            try
            {
                var book = _booksRepository.GetBookById(bookId);
                if (book.UserId != userId)
                {
                    book.UserId = null;
                    throw new BookNotBorrowedException(
                        "Book is not borrowed by you but thanks for bringing it back");
                }
                if (book.UserId is null)
                {
                    book.UserId = null;
                    throw new BookNotBorrowedException(
                        "Accoding to out noted, book is not borrowed. Thanks for bringin it.");
                }
                book.UserId = null;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"LOG: Book with id {bookId} does not exist");
                throw new BookDoesNotExistException(ex.Message, ex.InnerException);
            }

        }

    }
}

