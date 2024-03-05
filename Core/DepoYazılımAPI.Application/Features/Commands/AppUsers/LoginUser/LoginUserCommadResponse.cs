namespace DepoYazılımAPI.Application.Features.Commands.AppUsers.LoginUser
{
    public class LoginUserCommadResponse
    {
        
        
    }
    public class LoginUserSuccessCommandResponse: LoginUserCommadResponse 
    {
        public DTOs.Token token { get; set; }
    }
    public class LoginUserErrorCommandResponse: LoginUserCommadResponse
    {
        public string Message { get; set; }
    }
}
