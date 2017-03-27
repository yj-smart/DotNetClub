using DotNetClub.Core.Model.Auth;

namespace DotNetClub.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        public LoginModel Model { get; set; }

        public string ErrorMessage { get; set; }
    }
}
