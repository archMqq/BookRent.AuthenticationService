using System.Security.Cryptography;
using System.Text;

namespace BookRent.Authentication.Services
{
    public class PasswordHasher
    {
        public static string GenerateSalt(string userSymbol)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(userSymbol));
                return Convert.ToBase64String(saltBytes);
            }
        }

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

        public static bool VerifyPassword(string enteredPassword, string storedHash, string salt)
        {
            string enteredHash = HashPassword(enteredPassword, salt);
            return storedHash == enteredHash;
        }
    }
}
