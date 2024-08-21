namespace SchoolManagement.Application.ViewModels
{
    public class LoginUserViewModel
    {
      
        public string Token { get; private set; }
        public string Email { get; private set; }

        public LoginUserViewModel(string email, string token)
        {
            Token = token;
            Email = email;
        }
    }
}
