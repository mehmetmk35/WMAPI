using DepoYazılımAPI.Application.Abstractions.Services;
using DepoYazılımAPI.Application.Abstractions.Token;
using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommadHandler : IRequestHandler<LoginUserCommadRequest, LoginUserCommadResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommadHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommadResponse> Handle(LoginUserCommadRequest request, CancellationToken cancellationToken)
        {
           DTOs.Token result= await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 5);
            return new LoginUserSuccessCommandResponse() { token = result };
        }
    }
}
