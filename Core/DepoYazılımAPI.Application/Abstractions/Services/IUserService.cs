using DepoYazılımAPI.Application.DTOs.User;
using DepoYazılımAPI.Domin.Entity.Identity;

namespace DepoYazılımAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task UpdateRefreshToken(string refreshToken, AppUser user,DateTime accesTokenDate, int addOnAccessTokenDate);

    }
}
