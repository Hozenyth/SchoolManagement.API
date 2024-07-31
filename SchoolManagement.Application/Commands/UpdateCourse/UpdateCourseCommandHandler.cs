using MediatR;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public UpdateCourseCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _dbContext.Courses.SingleOrDefault(c => c.Id == request.Id);
            if (course != null)
                course.Update(request.Title, request.Description);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
