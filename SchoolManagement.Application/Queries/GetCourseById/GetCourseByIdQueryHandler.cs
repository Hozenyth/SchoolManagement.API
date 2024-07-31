using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDetailsViewModel>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetCourseByIdQueryHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CourseDetailsViewModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _dbContext.Courses
                .Include(c => c.Teacher)
                .SingleOrDefaultAsync(c => c.Id == request.Id);

            if (course == null) return null;
            
                var courseDetailsViewModel = new CourseDetailsViewModel(
                    course.Id,
                    course.Title,
                    course.Description,
                    course.CreatedAt,
                    course.StartedAt,
                    course.FinishedAt,
                    course.Teacher?.Name
                    );
                return courseDetailsViewModel;                       
        }
    }
}
