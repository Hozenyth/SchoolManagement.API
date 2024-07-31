using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CreateStudentCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            var currentRegistration = int.Parse(currentYear.ToString() + currentMonth.ToString() + request.Registration);
            request.Registration = currentRegistration;
            var student = new Student(request.Name, request.PhoneNumber, request.Registration, request.Email);
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return student.Registration;
        }

    }
}
