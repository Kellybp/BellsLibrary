using BellsLibrary.Data;
using BellsLibrary.Data.Initializer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BellsLibrary.API.Services.Extensions
{
    public static class HostExtensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            int numberOfEntities = 20;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BellsLibraryContext>();
                var isSeederRequired = context.Database.EnsureCreated();

                if(isSeederRequired)
                {
                    DataSeeder  _dataSeeder = new DataSeeder();

                    var books = _dataSeeder.GetBookGenerator().Generate(numberOfEntities);
                    context.AddRange(books);

                    var loans = _dataSeeder.GetLoanGenerator(books).Generate(numberOfEntities);
                    context.AddRange(loans);

                    context.SaveChanges(); 
                }
                
            }
        }
    }
}
