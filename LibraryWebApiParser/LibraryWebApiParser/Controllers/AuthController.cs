using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private IAuthService _authService;
        private IRegAndLogService _regAndLogService;

        public AuthController( ITokenService tokenService, IAuthService authService, IRegAndLogService regAndLogService)
        {
            _tokenService = tokenService;
            _authService = authService;
            _regAndLogService = regAndLogService;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterAndLoginDto dto)
        {
            if (_authService.IsUserExists(dto.Name))
                return BadRequest("User already Exists");
            return _regAndLogService.Register(dto) ? Ok("User was registered") : BadRequest("Failed to register");
        }
        [HttpPost("login")]
        public IActionResult Login(RegisterAndLoginDto loginDto)
        {
            if (!_authService.IsUserExists(loginDto.Name))
                return BadRequest("User not found.");

            if (!_authService.VerifyPasswordHash(loginDto))
                return BadRequest("Wrong password.");

            string token = _tokenService.CreateToken(loginDto);
            return Ok(token);
        }
    }
}
