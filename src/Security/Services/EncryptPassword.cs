using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Security.Services
{
    public static class EncryptPassword
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static string HashPassword(this string password, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = deriveBytes.GetBytes(20);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(this string passwordFromUser, byte[] salt, string passwordFromDB)
        {
            string newHash = HashPassword(passwordFromUser, salt);
             return newHash == passwordFromDB;

        }
    }
    

}
