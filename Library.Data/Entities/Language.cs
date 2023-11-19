using System;
namespace Library.Data.Entities
{
    public class Language
    {
        public Language(string code, string name)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
        }
        public readonly Guid Id;
        public string Code { get; private set; }
        public string Name { get; private set; }
    }
}

