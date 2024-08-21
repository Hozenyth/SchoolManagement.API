using MediatR;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Core.Services;

namespace SchoolManagement.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IStudentRepository _studentRepository;
        public LoginUserCommandHandler(IAuthService authService, IStudentRepository studentRepository)
        {
            _authService = authService;
            _studentRepository = studentRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
           
            var passwordHash = _authService.ComputeSha256Hash(request.Password);          
            var user = await _studentRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
          
            if (user == null)
            {
                return null;
            }
          
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
