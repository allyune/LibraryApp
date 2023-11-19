using System;
namespace Library.Data.Entities
{
    public class User
    {
        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}

