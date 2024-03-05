using MediatR;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.RefreshToken
{
    public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
