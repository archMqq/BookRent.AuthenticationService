using System.Text;
using System.Security.Cryptography;

namespace BookRent.Authentication.Security.Password.ServiceClasses
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password, string salt)
        {
            string passwordWithSalt = password + salt;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
