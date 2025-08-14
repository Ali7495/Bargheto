using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.Utilities
{
    public class PasswordHasher
    {
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool VerifyPassword(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
