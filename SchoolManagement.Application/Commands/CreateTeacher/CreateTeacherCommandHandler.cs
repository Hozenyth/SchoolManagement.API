using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.CreateTeacher
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly ITeacherRepository _teacherRepository;
        public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var currentDay = (DateTime.Now.Day).ToString();
            var currentYear = (DateTime.Now.Year).ToString();
            var currentMonth = (DateTime.Now.Month).ToString();

            var currentRegistration = int.Parse(currentYear + currentMonth + currentDay + request.Registration);
            request.Registration = currentRegistration;
            var teacher = new Teacher(request.Name, request.Email, request.Registration, request.PhoneNumber);           
            await _teacherRepository.AddAssync(teacher);           
            return teacher.Registration;
        }
    }
}
