
using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Library.Model.DataBaseContext;
using Library.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Library.BusinessLogic.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;
        private readonly IUserService _userService;
        public TokenService(IConfiguration configuration, ApplicationContext context, IUserService userService)
        {
            _configuration = configuration;
            _context = context;
            _userService = userService;
        }
        public string CreateToken(RegisterAndLoginDto logDto)
        {
            var user = _userService.Get(logDto.Name);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Name),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
