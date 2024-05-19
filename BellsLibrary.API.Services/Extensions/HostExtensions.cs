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

                //SeedDatabase
                if(isSeederRequired)
                {
                    DataSeeder _dataSeeder = new DataSeeder();

                    var books = _dataSeeder.GetBookGenerator().Generate(numberOfEntities);
                    context.AddRange(books);

                    var users = _dataSeeder.GetUserGenerator().Generate(3);
                    context.AddRange(users);

                    var loans = _dataSeeder.GetLoanGenerator(books, users).Generate(numberOfEntities);
                    context.AddRange(loans);

                    //var userRole = _dataSeeder.GetUserRoleGenerator(users).Generate(numberOfEntities);
                    //context.AddRange(userRole);

                    context.SaveChanges();
                }
            }
        }
    }
}
