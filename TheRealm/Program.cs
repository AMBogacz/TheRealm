using NLog;
using NLog.Web;
using StackExchange.Redis;
using TheRealm.Middlewares;
using TheRealm.Services;

namespace TheRealm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var multiplexer = ConnectionMultiplexer.Connect("localhost");
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
            builder.Services.AddSingleton<IRedisService, RedisService>();
            builder.Services.AddScoped<IMiningService, MiningService>();
            builder.Services.AddScoped<ILumberMillService, LumberMillService>();

            // Add Logger
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
            builder.Host.UseNLog();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}