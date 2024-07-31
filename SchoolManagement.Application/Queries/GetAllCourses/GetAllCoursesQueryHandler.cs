using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseViewModel>>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetAllCoursesQueryHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<List<CourseViewModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var course = _dbContext.Courses;
            var couserViewModel = await course
                .Select(c => new CourseViewModel(c.Id, c.Title, c.Description, c.CreatedAt, c.StartedAt, c.FinishedAt)).ToListAsync();

            return couserViewModel;
        }
    }
}
