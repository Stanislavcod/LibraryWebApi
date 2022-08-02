using Library.BusinessLogic.Interfaces;
using Library.Model.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Library.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        public AuthService(ApplicationContext context)
        {
            _context = context;
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        public bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computerHash.SequenceEqual(passwordHash);
        }
        public bool IsUserExists(string name)
        {
            return _context.Users.AsNoTracking().Any(x => x.Name == name.ToLower());
        }
    }
}
