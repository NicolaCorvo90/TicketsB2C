using Microsoft.EntityFrameworkCore;
using TicketsB2C.carriers;
using TicketsB2C.db;
using TicketsB2C.tickets;

namespace TicketsB2C;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        LoadEnv();
        
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MsSqlDbContext>(options => options.UseSqlServer(connectionString));
        
        DependencyInjection(builder);
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }

    private static void LoadEnv()
    {
        string envFilePath;
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            envFilePath = ".env";
        }
        else
        {
            envFilePath = Path.Combine(Directory.GetParent( Directory.GetCurrentDirectory()).Parent.Parent.FullName, ".env.test");;
        }
        
        DotNetEnv.Env.Load(envFilePath);
    }

    private static void DependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
        builder.Services.AddScoped<ITicketsService, TicketsService>();
        
        builder.Services.AddScoped<ICarriersRepository, CarriersRepository>();
    }
}
