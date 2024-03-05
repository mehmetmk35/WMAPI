using DepoYazılımAPI.Application.Abstractions.Services;
using DepoYazılımAPI.Application.Abstractions.Token;
using DepoYazılımAPI.Application.DTOs;
using DepoYazılımAPI.Application.Exceptions;
using DepoYazılımAPI.Domin.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DepoYazılımAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IUserService _userService;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<Token> LoginAsync(string UserNameOrEmail, string Password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(UserNameOrEmail);
            if (user == null)
                throw new NotFoundUserException("Kullanıcı Adı Yada Şifre Hatalı ");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, Password, false);
            if (result.Succeeded) //giriş başarılı 
            {

                Application.DTOs.Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5);
               
                return token;
            }

            //return new LoginUserErrorCommandResponse () { Message="Giriş işleminde hata"} ;
            //2side olur 
            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
              AppUser? user =await _userManager.Users.FirstOrDefaultAsync(x=>x.RefreshToken == refreshToken);
            if (user != null&& user?.RefreshTokenEndDate>DateTime.UtcNow) 
            {
              Token token=  _tokenHandler.CreateAccessToken(15, user);
               await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;

            }
            else
            throw new NotFoundUserException();
        }
    }
}
