using Library.BusinessLogic.Interfaces;
using Library.Presentation.Interfaces;
using System;
using System.Reflection;
namespace Library.Presentation.Services
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IEnumerable<ICommand> _commands;
        private readonly IBookService _bookService;
        public CommandHandler(IBookService bookService)
        {
            _bookService = bookService;
            _commands = LoadCommands();
        }

        private IEnumerable<ICommand> LoadCommands()
        {
            var commands = new List<ICommand>();
            commands.Add(new ListBorrowedBooks(_bookService));
            commands.Add(new BorrowBook(_bookService));
            commands.Add(new ListAllBooks(_bookService));
            commands.Add(new ListOneBook(_bookService));
            commands.Add(new ReturnBook(_bookService));
            return commands;
        }

        private ICommand MatchCommand(string input)
        {
            var command =  _commands.FirstOrDefault(c => c.getTitle() ==  input);
            if(command is null) 
                throw new InvalidOperationException("Command not found");
            return command;
        }

        public void ExecuteCommand(string input)
        {
            try
            {
                var command = MatchCommand(input);
                command.Execute();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }
    }
}

