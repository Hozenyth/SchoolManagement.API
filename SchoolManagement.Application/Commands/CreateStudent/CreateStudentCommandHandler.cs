using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Core.Services;

namespace SchoolManagement.Application.Comands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAuthService _authService;
        public CreateStudentCommandHandler(IStudentRepository studentRepository, IAuthService authService)
        {
            _studentRepository = studentRepository;
            _authService = authService;
        }
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {    
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var currentRegistration = GenerateRegistration(request.Registration);
            request.Registration = currentRegistration;
            var student = new Student(request.Name, request.PhoneNumber, request.Registration, request.Email, request.Role, passwordHash);
            await _studentRepository.AddAsync(student);
            
            return student.Registration;
        }

        public int GenerateRegistration(int registration) 
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            var currentRegistration = int.Parse(currentYear.ToString() + currentMonth.ToString() + registration);

            return currentRegistration;
        }

    }
}
