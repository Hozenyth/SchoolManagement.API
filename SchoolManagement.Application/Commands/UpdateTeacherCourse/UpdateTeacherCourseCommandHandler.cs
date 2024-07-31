using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Comands.UpdateTeacherCourse;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.UpdateTeacherCourse
{
    public class UpdateTeacherCourseCommandHandler : IRequestHandler<UpdateTeacherCourseCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;

        public UpdateTeacherCourseCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTeacherCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _dbContext.Courses.SingleOrDefaultAsync(c => c.Id == request.Id);
            if (course != null)
                course.UpdateTeacherCourse(request.TeacherId);

            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
