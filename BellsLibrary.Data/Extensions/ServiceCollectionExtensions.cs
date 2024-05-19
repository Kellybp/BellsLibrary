using BellsLibrary.Data.Contracts;
using BellsLibrary.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BellsLibrary.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBellsLibraryData(this IServiceCollection services,
       IConfiguration configuration,
       bool isProduction = true)
        {
            var bellsLibraryConnectionString = configuration["ConnectionStrings:BellsLibrary"];

            services.AddDbContext<BellsLibraryContext>(options =>
            {
                options.UseSqlServer(bellsLibraryConnectionString);
                //If we are not in production, log to console
                if (!isProduction)
                {
                    options.LogTo(Console.WriteLine);
                }
            });
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }
    }
}
