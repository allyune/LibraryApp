using System;
using Library.BusinessLogic.DTOs;

namespace Library.Presentation.Utils
{
	public static class PresentationUtils
	{
        public static string GetInput()
        {
            string? result = string.Empty;
            while (string.IsNullOrEmpty(result))
            {
                result = Console.ReadLine();
            }
            return result;
        }

        public static void PrintBookInfo(BookDTO book)
        {
            Console.WriteLine($"ID: {book.BookId}");
            Console.WriteLine($"Name: {book.Name}");
            Console.WriteLine($"Author Name: {book.AuthorName}");
            Console.WriteLine($"Author Surname: {book.AuthorSurname}");
            Console.WriteLine($"Category: {book.CategoryName}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Year Published: {book.YearPublished}");
            Console.WriteLine($"Language: {book.Language}");
            Console.WriteLine($"User ID: {book.UserId}");
        }

        public static int ParseCommand(string command)
        {
            bool commandValid = int.TryParse(command, out int commandInt);
            if (!commandValid)
                throw new ArgumentException("Command is not valid");
            return commandInt;
        }
    }
}

