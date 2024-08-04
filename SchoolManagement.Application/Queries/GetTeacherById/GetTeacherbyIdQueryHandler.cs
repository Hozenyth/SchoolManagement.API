using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetTeacherById
{
    public class GetTeacherbyIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDetailsViewModel>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetTeacherbyIdQueryHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TeacherDetailsViewModel> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.SingleOrDefaultAsync(p => p.Registration == request.Registration);

            if (teacher == null) return null;

            var teacherDetailsViewModel = new TeacherDetailsViewModel(

                teacher.Name,
                teacher.PhoneNumber,
                teacher.Registration
            );

            return teacherDetailsViewModel;
        }
    }
}
