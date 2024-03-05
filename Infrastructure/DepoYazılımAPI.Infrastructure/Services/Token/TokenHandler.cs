using DepoYazılımAPI.Application.Abstractions.Token;
using DepoYazılımAPI.Domin.Entity.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DepoYazılımAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int second,AppUser appUser)
        {
            Application.DTOs.Token token  = new();
            //SymmetricSecurityKey key'in simeetriğini alıyorz 
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            //Şifrelenmiş kimliği oluşturuyorz
            SigningCredentials signingCredentials = new(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            //oluşturulacak token ayarlarını veriyorz 
            token.Expiration=DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken tokenSecurityToken = new
                (audience: _configuration["Token:Audience"],
                issuer:_configuration["Token:Issuer"],
                expires:token.Expiration,
                notBefore:DateTime.UtcNow,//TOKEN URETILIR URETILMEZ DEVREYE GIRMESINI AYARLIYORZ HEMEN DEVREDE 
                signingCredentials:signingCredentials,
                claims:new List<Claim> { new(ClaimTypes.Name, appUser.UserName) }
                );
            //Token Oluşturucusunda Bir örnek al
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken=jwtSecurityTokenHandler.WriteToken(tokenSecurityToken);

            //kullanıcı giriş sağladığında refresh token oluştur gerçek token işlemi bittiğinde refresh ile devam etederkten yenı bir toekn oluşturulack
          
            token.RefreshToken= CreateRefreshToken();
            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];

            using  RandomNumberGenerator random= RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
