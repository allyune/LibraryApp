using System;
namespace Library.BusinessLogic.DTOs
{
	public class BookDTO
	{
        public Guid BookId;
        public string Name;
        public string AuthorName;
        public string AuthorSurname;
        public string CategoryName;
        public string ISBN;
        public int YearPublished;
        public string Language;
        public Guid? UserId;

        public BookDTO(
            Guid id,
            string name,
            string authorName,
            string authorSurname,
            string categoryName,
            string iSBN,
            int yearPublished,
            string language,
            Guid? userId = null)
        {
            BookId = id;
            Name = name;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            CategoryName = categoryName;
            ISBN = iSBN;
            YearPublished = yearPublished;
            Language = language;
            UserId = userId;
        }
    }
}

