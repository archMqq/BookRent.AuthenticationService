using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRent.Authentication.Security.Password.ServiceClasses
{
    public static class SaltSymbolGenerator
    {
        public static char GenerateSymbol()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int index = random.Next(chars.Length);
            return chars[index];
        }
    }
}
