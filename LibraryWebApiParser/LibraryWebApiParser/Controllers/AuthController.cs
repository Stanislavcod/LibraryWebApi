using Library.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private IAuthService _authService;
        private IRegAndLogService _regAndLogService;

        public AuthController(IUserService userService, ITokenService tokenService, IAuthService authService, IRegAndLogService regAndLogService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _authService = authService;
            _regAndLogService = regAndLogService;
        }
    }
}
