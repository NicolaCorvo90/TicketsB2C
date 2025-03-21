using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TicketsB2C.carriers;
using TicketsB2C.db;
using TicketsB2C.discounts;
using TicketsB2C.jwt;
using TicketsB2C.tickets;
using TicketsB2C.users;

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
        
        byte[] key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
        
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

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
        builder.Services.AddScoped<IJwtService, JwtService>();
        
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<IUsersService, UsersService>();
        
        builder.Services.AddScoped<ITicketsRepository, TicketsRepository>();
        builder.Services.AddScoped<ITicketsService, TicketsService>();
        
        builder.Services.AddScoped<ICarriersRepository, CarriersRepository>();

        builder.Services.AddScoped<IDiscountService, DiscountService>();
    }
}
