using ECommerce.Application;
using ECommerce.Domain;
using ECommerce.Infrastructure;
using ECommerce.Persistence;
using ECommerce.Security;

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServiceRegistiration();
            builder.Services.AddSecurityServiceRegistiration(builder.Configuration);
            builder.Services.AddInfrastructureServicesRegistiration(builder.Configuration);
            builder.Services.AddPersistenceServiceRegistiration(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}