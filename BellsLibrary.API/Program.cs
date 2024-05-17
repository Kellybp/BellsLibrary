
using BellsLibrary.API.Services.Extensions;
namespace BellsLibrary.API.MVC;

public class Program {

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Register App Services
        AddApplicationServices(builder);

        //Register MVC Services
        AddMvcServices(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureMvcServices(app);

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

        app.UseAuthorization();

        app.MapControllers();
    }

    private static void AddMvcServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    private static void AddApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddBellsLibraryServices(builder.Configuration,
                                                 builder.Environment.IsProduction());
    }

}