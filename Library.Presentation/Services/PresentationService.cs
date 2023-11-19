using System.Reflection;
using System.Text.RegularExpressions;
using Library.Presentation.Interfaces;
using Library.Presentation.Utils;

namespace Library.Presentation.Services
{
    public class PresentationService : IPresentationService
    {
        private readonly ICommandHandler _commandHandler;
        public PresentationService(ICommandHandler commandHandler)
        {
            _commandHandler = commandHandler;        
        }
        public void Run()
        {
            var running = true;
            while (running)
            {
                Console.WriteLine("What would you like to do?");
                var command = Console.ReadLine();
                if (string.IsNullOrEmpty(command))
                {
                    continue;
                }
                if (command.Equals("exit"))
                {
                    Console.WriteLine("Bye!");
                    break;
                }
                ProcessCommand(command);
            }
        }

        private void ProcessCommand(string command)
        {
            try
            {
                _commandHandler.ExecuteCommand(command);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid command");
                return;
            }
        }


    }
}

