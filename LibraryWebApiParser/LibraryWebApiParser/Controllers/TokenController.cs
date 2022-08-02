using Library.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("Create token")]
        public ActionResult<string> CreateToken([FromQuery] int id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return BadRequest("User is not found");
            }
            string token = _tokenService.CreateToken(user);
            _userService.Update(user);
            return Ok(token);
        }
    }
}
