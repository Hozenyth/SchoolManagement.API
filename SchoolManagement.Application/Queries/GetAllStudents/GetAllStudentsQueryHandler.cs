using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Infrastructure.Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolManagement.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentViewModel>>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetAllStudentsQueryHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = _dbContext.Students;
            var studentViewModel = await students.Select(p => new StudentViewModel(p.Id, p.Name, p.Registration, p.Email)).ToListAsync();

            return studentViewModel;
        }
    }
}
