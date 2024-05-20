using BellsLibrary.UI.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using BellsLibrary.UI.Services.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BellsLibrary.Data;

namespace BellsLibrary.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddUIServices(builder);

            AddBlazorComponents(builder);

            var app = builder.Build();

            ConfigureBlazorComonents(app);

            app.Run();
        }
        private static void ConfigureBlazorComonents(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
        }

        private static void AddUIServices(WebApplicationBuilder builder)
        {
            builder.Services.AddUIServices(builder.Configuration);
        }

        private static void AddBlazorComponents(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorComponents()
                            .AddInteractiveServerComponents();

            builder.Services.AddFluentUIComponents();

            builder.Services.AddAuthorization();
        }
    
    }
}