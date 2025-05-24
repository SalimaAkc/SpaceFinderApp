using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;

namespace SpacefinderApp.Utilities
{
    internal static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        internal static bool Verify(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch (SaltParseException)
            {
                return false;
            }
        }
    }
}
