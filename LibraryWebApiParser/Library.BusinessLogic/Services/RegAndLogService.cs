
using AutoMapper;
using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Library.Model.DataBaseContext;
using Library.Model.Models;
using System.Security.Cryptography;
using System.Text;

namespace Library.BusinessLogic.Services
{
    public class RegAndLogService : IRegAndLogService
    {
        private readonly ITokenService _token;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public RegAndLogService(ITokenService token, IMapper mapper,ApplicationContext context)
        {
            _context = context;
            _token = token;
            _mapper = mapper;   
        }
        public bool Register(RegisterAndLoginDto register)
        {
            var user = _mapper.Map<User>(register);
            _context.Users.Add(user);
            return _context.SaveChanges()>0 ? true : false;
        }
        public UserDto Login(RegisterAndLoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(x => x.Name == loginDto.Name);
            if (user == null) return null!;

            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != user.PasswordHash[i]) return null!;

            var userDto = _mapper.Map<User, UserDto>(user);
            userDto.Token = _token.CreateToken(user.Id);
            return userDto;
        }
    }
}
