using System.Security.Cryptography;

namespace BookRent.Authentication.Security.Password.ServiceClasses
{
    public class PasswordVerifier
    {
        public static bool VerifyPassword(string enteredPassword, string storedHash, string salt)
        {
            string enteredHash = PasswordHasher.HashPassword(enteredPassword, salt);
            return storedHash == enteredHash;
        }
    }
}
