using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BellsLibrary.API.Services.Contracts;
using BellsLibrary.Data.Extensions;
using BellsLibrary.API.Services.Services;

namespace BellsLibrary.API.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBellsLibraryServices(this IServiceCollection services,
           IConfiguration configuration,
           bool isProduction = true)
        {
            services.AddBellsLibraryData(configuration, isProduction);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            return services;
        }
    }
}
