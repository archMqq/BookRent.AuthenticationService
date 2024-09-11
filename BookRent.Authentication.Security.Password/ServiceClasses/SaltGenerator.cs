using System.Security.Cryptography;
using System.Text;

namespace BookRent.Authentication.Security.Password.ServiceClasses
{
    public class SaltGenerator
    {
        public static string GenerateSalt(string userSymbol)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(userSymbol));
                return Convert.ToBase64String(saltBytes);
            }
        }
        
    }
}
