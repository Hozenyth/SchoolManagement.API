using MediatR;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Comands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetDetailsByIdAsync(request.Id);
            if (course != null)
                course.Update(request.Title, request.Description);

            await _courseRepository.UpdateChangesAsync();

            return Unit.Value;
        }
    }
}
