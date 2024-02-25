using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommadRequest:IRequest<LoginUserCommadResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
