using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
          IdentityResult result=  await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.Username,
                Email = request.Email

            }, request.Password);
            CreateUserCommandResponse response= new CreateUserCommandResponse() {Succeeded=result.Succeeded};

            if (result.Succeeded)
            {
                  response.Message = "Kayıt Başarılı";
            }
            else              
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}\n";
                }
            
            return response;
            //throw new UserCreateFailedException();
        }
    }
}
