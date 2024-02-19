using ECommerce.Application.Interfaces.Service.Email;
using ECommerce.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace ECommerce.Infrastructure
{
    public  static class InfrastructureServicesRegistiration
    {
        public static void AddInfrastructureServicesRegistiration(this IServiceCollection service, IConfiguration configuration = null,string logFileName="log.txt")
        {
            service.AddTransient<IEmailService, SmtpEmailSender>();
            service.Configure<EmailSettings>(x => configuration.GetSection("EmailSettings"));

            service.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();
            });

            LogManager.Configuration.Variables["logFileName"] = logFileName;
        }
    }
}

 