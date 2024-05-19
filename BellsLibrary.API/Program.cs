
using BellsLibrary.API.Services.Extensions;
using BellsLibrary.Data;
using BellsLibrary.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace BellsLibrary.API.MVC;

public class Program {

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Register App Services
        AddApplicationServices(builder);

        //Register MVC Services
        AddMvcServices(builder);

        AddAuthentication(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureMvcServices(app);

        app.MapIdentityApi<ApplicationUser>();

        app.CreateDbIfNotExists();

        app.Run();
    }

    private static void ConfigureMvcServices(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }

    private static void AddMvcServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
    }

    private static void AddApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddBellsLibraryServices(builder.Configuration,
                                                 builder.Environment.IsProduction());
    }

    private static void AddAuthentication(WebApplicationBuilder builder)
    {

        builder.Services.AddAuthorization();

        builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<BellsLibraryContext>();

        //Swagger Authentication
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }

}