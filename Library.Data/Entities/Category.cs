using System;
namespace Library.Data.Entities
{
    public class Category
    {
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public readonly Guid Id;
        public string Name { get; private set; }


    }
}

