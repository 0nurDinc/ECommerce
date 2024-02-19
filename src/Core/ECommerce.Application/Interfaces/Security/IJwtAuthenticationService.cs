using ECommerce.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Security
{
    public interface IJwtAuthenticationService
    {
        Task<string> Authenticate(string username, string password);
        Task<bool> Register(UserRegisterVM userRegisterVM);
    }
}
