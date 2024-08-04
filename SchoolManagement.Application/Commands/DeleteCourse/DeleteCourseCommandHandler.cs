using MediatR;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public DeleteCourseCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _dbContext.Courses.SingleOrDefault(c => c.Id == request.Id);

            if (course != null)
                course.Cancel();

           await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
