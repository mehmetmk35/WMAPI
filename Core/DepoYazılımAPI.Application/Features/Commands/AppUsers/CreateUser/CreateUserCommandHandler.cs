using DepoYazılımAPI.Application.Abstractions.Services;
using DepoYazılımAPI.Application.DTOs.User;
using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {   readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

       

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

             CreateUserResponse result= await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                Username = request.Username,
                PasswordConfirm = request.PasswordConfirm
            });
            return new() { Message = result.Message,Succeeded=result.Succeeded };
        }
    }
}
