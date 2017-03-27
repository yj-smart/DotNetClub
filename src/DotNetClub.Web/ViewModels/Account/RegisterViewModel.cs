using DotNetClub.Core.Model.Auth;

namespace DotNetClub.Web.ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterModel Model { get; set; }

        public string ErrorMessage { get; set; }
    }
}
