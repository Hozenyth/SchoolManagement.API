using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CreateCourseCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var createCourse = new Course(request.Title, request.Description);

            await _dbContext.Courses.AddAsync(createCourse);
            await _dbContext.SaveChangesAsync();

            return createCourse.Id;
        }
    }
}
