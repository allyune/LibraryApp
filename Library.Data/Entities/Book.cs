using System;
namespace Library.Data.Entities
{
    public class Book
    {
        public readonly Guid Id;

        public Book(
            string name, Author author,
            Category category, string isbn,
            int yearPublished, Language language,
            Guid? userId = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Author = author;
            Category = category;
            ISBN = isbn;
            YearPublished = yearPublished;
            Language = language;
            UserId = userId;
        }

        public string Name { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }
        public string ISBN { get; private set; }
        public int YearPublished { get; private set; }
        public Language Language { get; private set; }
        public Guid? UserId { get; set; }
    }

}

