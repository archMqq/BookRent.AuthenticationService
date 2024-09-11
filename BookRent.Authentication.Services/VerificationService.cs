using BookRent.ServiceClasses;
using BookRent.Authentication.Security.Password;
using BookRent.Models;
using Microsoft.EntityFrameworkCore;
using BookRent.Authentication.Security.Password.ServiceClasses;

namespace BookRent.Authentication.Services
{
    public class VerificationService
    {
        private readonly BookRentContext _context;
        public async Task<ServiceResult<bool>> Verificate(string username, string password)
        {
            var user = await _context.Users.Where(u => u.UserLogin == username).FirstOrDefaultAsync();
            if (user == null)
                return new ServiceResult<bool>
                {
                    NotFound = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Не найден пользователь с таким именем",
                        Fields = new[] { username }
                    }
                };

            return PasswordVerifier.VerifyPassword(password, user.Password, user.UserSalt.ToString()) == true
                ? new ServiceResult<bool>
                {
                    Ok = true,
                    Result = true
                }
                : new ServiceResult<bool>
                {
                    BadRequest = true,
                    Errors = new ServiceErrors
                    {
                        Error = "Не верный пароль!",
                        Fields = new[] { password }
                    }
                };
        }
    }
}
