using DepoYazılımAPI.Application.Abstractions.Services;
using DepoYazılımAPI.Application.DTOs;
using MediatR;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        readonly IAuthService _authService;

        public RefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
           Token token=await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new() { Token=token };
        }
    }
}
