using System;
using Library.BusinessLogic.Interfaces;
using Library.BusinessLogic.Services;
using Library.Presentation.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Library.BusinessLogic;
using Library.Presentation.Services;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IPresentationService, PresentationService>()
            .AddTransient<IBookService, BookService>()
            .AddTransient<IListAllBooks, ListAllBooks>()
            .AddTransient<IListOneBook, ListOneBook>()
            .AddTransient<IBorrowBook, BorrowBook>()
            .AddTransient<IListBorrowedBooks, ListBorrowedBooks>()
            .AddTransient<IReturnBook, ReturnBook>()
            .AddTransient<ICommandHandler, CommandHandler>()
            .AddBusinessLogicDependencies()
            .BuildServiceProvider();

        var presentationService = serviceProvider.GetRequiredService<IPresentationService>();
        presentationService.Run();
    }
}
