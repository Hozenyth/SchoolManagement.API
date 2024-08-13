using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application.Comands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {            
            var currentRegistration = GenerateRegistration(request.Registration);
            request.Registration = currentRegistration;
            var student = new Student(request.Name, request.PhoneNumber, request.Registration, request.Email);
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
