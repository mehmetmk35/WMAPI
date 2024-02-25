using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommadHandler : IRequestHandler<LoginUserCommadRequest, LoginUserCommadResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public LoginUserCommadHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommadResponse> Handle(LoginUserCommadRequest request, CancellationToken cancellationToken)
        {
           AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new NotFoundUserException("Kullanıcı Adı Yada Şifre Hatalı ");

            SignInResult result= await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if (result.Succeeded) //giriş başarılı 
            {

                //yetkiler
            }
              
            return new();
        }
    }
}
