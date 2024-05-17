using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BellsLibrary.UI.Services.Contracts;

namespace BellsLibrary.UI.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiUrl = configuration["Api:Url"]!;
            services.AddHttpClient("AdminApi", client =>
            {
                client.BaseAddress = new Uri(apiUrl, UriKind.Absolute);
            });
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanService, LoanService>();
            return services;
        }
    }
}
