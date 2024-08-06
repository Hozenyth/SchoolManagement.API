using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDetailsViewModel>
    {
        private readonly ICourseRepository _courseRepository;
        public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<CourseDetailsViewModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetDetailsByIdAsync(request.Id);

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
