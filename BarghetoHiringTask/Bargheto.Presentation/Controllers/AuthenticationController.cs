using Bargheto.Application.DataTransferObjects;
using Bargheto.Application.DataTransferObjects.UserManagement;
using Bargheto.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bargheto.Presentation.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserManagementServices _userManagementServices;

        public AuthenticationController(IUserManagementServices userManagementServices)
        {
            _userManagementServices = userManagementServices;
        }

        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterUser([FromBody] UserInputDto userInputDto, CancellationToken cancellationToken)
        {
            ResultStatusDto result = await _userManagementServices.CreateUser(userInputDto,cancellationToken);
            return Ok(result);
        }

        [HttpPost("auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto,CancellationToken cancellationToken)
        {
            TokenRespons tokenRespons = await _userManagementServices.LoginUser(loginDto,cancellationToken);
            return Ok(tokenRespons);
        }


    }
}
