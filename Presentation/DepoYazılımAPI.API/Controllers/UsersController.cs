using DepoYazılımAPI.Application.Features.Commands.AppUsers.CreateUser;
using DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DepoYazılımAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest) 
        {
             CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return   Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommadRequest loginUserCommadRequest) 
        {
            LoginUserCommadResponse response = await _mediator.Send(loginUserCommadRequest);
            return Ok(response);
        }
    }
}
