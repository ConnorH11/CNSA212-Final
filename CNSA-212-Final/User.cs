using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CNSA_212_Final
{
    public class User
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public bool SetPassword(string password)
        {
            try
            {
                // generate a salt
                Salt = GenerateSalt();

                // hash the password with the salt
                HashedPassword = HashPassword(password, Salt);

                return true;
            }
            catch (Exception)
            {
                // returns if false
                return false;
            }
        }

        // private method to generate a salt
        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16]; // 128-bit salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes); // Convert the salt to a Base64 string
        }

        // Private method to hash the password with the salt
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes); // Convert the hash to a Base64 string
            }
        }
    }
}