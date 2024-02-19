using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.Security
{
    public interface IHashHelper
    {
        byte[] GenerateSalt();
        byte[] HashPassword(string password, byte[] salt);
        bool IsValidPassword(string enteredPassword, byte[] storedPasswordHash, byte[] salt);

    }
}
