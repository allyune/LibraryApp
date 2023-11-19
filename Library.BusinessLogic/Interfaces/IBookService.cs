using System;
using Library.BusinessLogic.DTOs;
using Library.Data.Entities;

namespace Library.BusinessLogic.Interfaces
{
	public interface IBookService
	{
		public List<BookDTO> GetBooks();
		public BookDTO GetBookById(Guid id);
		public void BorrowBook(Guid bookId, Guid userId);
		public List<BookDTO> GetBorrowedBookByUser(Guid usedId);
		public void ReturnBook(Guid bookId, Guid userId);
    }
}

