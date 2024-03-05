using DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser;
using DepoYazılımAPI.Application.Features.Commands.AppUsers.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommadRequest loginUserCommadRequest)
        {
            bool a = ModelState.IsValid;
            LoginUserCommadResponse response = await _mediator.Send(loginUserCommadRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenCommandRequest refreshTokenCommandRequest)
        {
            RefreshTokenCommandResponse response = await _mediator.Send(refreshTokenCommandRequest);

            return Ok(response);
        }
    }
}
