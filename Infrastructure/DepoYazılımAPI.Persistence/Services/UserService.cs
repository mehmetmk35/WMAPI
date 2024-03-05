using DepoYazılımAPI.Application.Abstractions.Services;
using DepoYazılımAPI.Application.DTOs.User;
using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                UserName = model.Username,
                Email = model.Email

            }, model.Password);
            CreateUserResponse response = new CreateUserResponse() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kayıt Başarılı";
            }
            else
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}\n";
                }
            //throw new UserCreateFailedException();
            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accesTokenDate,int addOnAccessTokenDate)
        {
        
            if (user != null) 
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate= accesTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
                 
            }
            else
            throw new NotFoundUserException();
        }
    }
}
