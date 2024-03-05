using DepoYazılımAPI.Application.DTOs;
using DepoYazılımAPI.Domin.Entity.Identity;

namespace DepoYazılımAPI.Application.Abstractions.Token
{
    public interface  ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second,AppUser appUser); //AppUser log için kullanıcı bilgi lazım ondan dolayı tokena bu kullanıcıuı alabileceği bir parametre lazım
        string CreateRefreshToken();
    }
}
