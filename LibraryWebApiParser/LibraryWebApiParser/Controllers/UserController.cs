using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRegAndLogService _regAndLogService;

        public UserController(IUserService userService, IRegAndLogService regAndLogService)
        {
            _userService = userService;
            _regAndLogService = regAndLogService;
        }
        [HttpGet("GetUsers"),Authorize]
        public IActionResult Get()
        {
            return Ok(_userService.Get());
        }
        [HttpGet("{id}"),Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_userService.Get(id));
        }

        [HttpDelete("DeleteAccount"),Authorize]
        public IActionResult DeleteAccount([FromQuery]int id)
        {
            _userService.Deleted(id);
            return Ok("Account Deleted");
        }
        [HttpPut("Edit"),Authorize]
        public IActionResult Put (UserDto userDto)
        {
            _userService.Update(userDto);
            return Ok();
        }
    }
}
