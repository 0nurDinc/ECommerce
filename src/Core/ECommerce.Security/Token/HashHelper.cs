using ECommerce.Application.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Security.Token
{
    public class HashHelper : IHashHelper
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password).Concat(salt).ToArray());
            }
        }

        public bool IsValidPassword(string enteredPassword, byte[] storedPasswordHash, byte[] salt)
        {
            byte[] enteredPasswordHash = HashPassword(enteredPassword, salt);
            return enteredPasswordHash.SequenceEqual(storedPasswordHash);
        }
    }
}
