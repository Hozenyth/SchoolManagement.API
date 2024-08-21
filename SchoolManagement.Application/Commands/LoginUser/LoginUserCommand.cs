using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
