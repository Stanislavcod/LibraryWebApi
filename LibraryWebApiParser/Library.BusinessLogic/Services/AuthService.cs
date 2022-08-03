using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Library.Model.DataBaseContext;
using Library.Model.Models;
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
        public bool VerifyPasswordHash(RegisterAndLoginDto loginDto)
        {
            var user = Get(loginDto.Name)!;
            using (var hmac = new HMACSHA256(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }
        public User Get(string name) =>
           _context.Users.AsNoTracking().FirstOrDefault(u => u.Name == name)!;
        public bool IsUserExists(string name)
        {
            return _context.Users.AsNoTracking().Any(x => x.Name == name.ToLower());
        }
    }
}
