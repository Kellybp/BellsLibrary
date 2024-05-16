using BellsLibrary.Data.Extensions;
using BellsLibrary.Data.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BellsLibrary.App.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //load configuration
            var configuration = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddBellsLibraryData(configuration, false)
                .BuildServiceProvider();

            //Get Sauce Repository
            var bookRepository = serviceProvider.GetService<IBookRepository>()!;

            //Get all books
            var books = await bookRepository.GetAllAsync();

            //Display all books
            foreach (var book in books)
            {
                System.Console.WriteLine($"Book Id: {book.Id}, Title: {book.Title}");
            }
            System.Console.WriteLine("Press any key to close...");
            System.Console.ReadKey();
        }
    }
}
