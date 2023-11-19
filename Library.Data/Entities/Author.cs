using System;
namespace Library.Data.Entities
{
    public class Author
    {
        public Author(string name, string surname)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
        }

        public readonly Guid Id;
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}