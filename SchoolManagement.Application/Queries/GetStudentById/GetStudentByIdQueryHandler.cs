using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDetailsViewModel>
    {
        private readonly SchoolManagementDbContext _dbContext;       
        public GetStudentByIdQueryHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;           
        }
        public async Task<StudentDetailsViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students
                .SingleOrDefaultAsync(p => p.Registration == request.Registration);
           
            if (student == null) return null;

            var studentDetailViewModel = new StudentDetailsViewModel(
                student.Id,
                student.Name,
                student.Registration,
                student.PhoneNumber,
                student.Email,
                student.CreatedAt);

            return studentDetailViewModel;
        }
    }
}
