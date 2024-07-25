using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.CreateTeacher
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CreateTeacherCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var currentDay = (DateTime.Now.Day).ToString();
            var currentYear = (DateTime.Now.Year).ToString();
            var currentMonth = (DateTime.Now.Month).ToString();

            var currentRegistration = int.Parse(currentYear + currentMonth + currentDay + request.Registration);
            request.Registration = currentRegistration;
            var teacher = new Teacher(request.Name, request.Email, request.Registration, request.PhoneNumber);           
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();

            return teacher.Registration;
        }
    }
}
