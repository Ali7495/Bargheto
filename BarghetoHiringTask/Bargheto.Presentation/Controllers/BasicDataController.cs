using Bargheto.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bargheto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicDataController : ControllerBase
    {
        private readonly IUserManagementServices _userManagementServices;

        public BasicDataController(IUserManagementServices userManagementServices)
        {
            _userManagementServices = userManagementServices;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
        {
            return Ok(await _userManagementServices.GetRoles(cancellationToken));
        }
    }
}
