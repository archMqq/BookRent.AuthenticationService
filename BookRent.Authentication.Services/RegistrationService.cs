using BookRent.ServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRent.Models


using System.Data;
using BookRent.Authentication.Security.Password.ServiceClasses;

namespace BookRent.Authentication.Services
{
    public class RegistrationService
    {
        private readonly BookRentContext _context;
        public async Task<ServiceResult<User>> RegisterUser(User user)
        {
            user.UserSalt = SaltSymbolGenerator.GenerateSymbol();
            user.Password = PasswordHasher.HashPassword(user.Password, user.UserSalt.ToString());
            await _context.Users.AddAsync(user);
            try
            {
                await _context.SaveChangesAsync();
                return new ServiceResult<User>()
                {
                    Ok = true,
                    Result = user
                };
            }
            catch (DBConcurrencyException concEx)
            {
                return new ServiceResult<User>()
                {
                    BadRequest = true,
                    Errors = new ServiceErrors()
                    {
                        Error = "Ошибка при вставке нового пользователя"
                    }
                };
            }
            catch (OperationCanceledException cancelEx)
            {
                return new ServiceResult<User>()
                {
                    BadRequest = true,
                    Errors = new ServiceErrors()
                    {
                        Error = "Ошибка при вставке нового пользователя"
                    }
                };
            }
        }
    }
}
