using ECommerce.Application.Interfaces.Security;
using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Security.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Security
{
    public static class SecurityServiceRegistiration
    {
        public static void AddSecurityServiceRegistiration(this IServiceCollection services,IConfiguration configuration = null)
        {

            // Register dependencies
            services.AddTransient<IHashHelper, HashHelper>();

            // Register JwtCustomerAuthenticationService
            services.AddTransient<IJwtAuthenticationService, JwtCustomerAuthenticationService>();
        }
    }
}
