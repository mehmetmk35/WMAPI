using DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser;
using FluentValidation;

namespace DepoYazılımAPI.Application.Validators.Login
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommadRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserNameOrEmail).NotNull().NotEmpty().WithMessage("Kullanıcı  bilgileri girilmelidir");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Kullanıcı  bilgileri girilmelidir");
             
        }
    }
}
