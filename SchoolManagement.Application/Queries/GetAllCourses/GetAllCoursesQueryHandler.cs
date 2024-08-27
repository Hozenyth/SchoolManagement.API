using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseViewModel>>
    {
        private readonly ICourseRepository _courseRepository;
        public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<List<CourseViewModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAllAsync();

            var couserViewModel = course
                .Select(c => new CourseViewModel(c.Id, c.Title, c.Description, c.CreatedAt, c.StartedAt, c.FinishedAt)).ToList();

            return couserViewModel;
            
        }
    }
}
