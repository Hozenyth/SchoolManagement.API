using MediatR;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application.Comands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
    {

        private readonly ICourseRepository _courseRepository;
        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {

            _courseRepository = courseRepository;
        }
        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var createCourse = new Course(request.Title, request.Description);
            await _courseRepository.AddAsync(createCourse);

            return createCourse.Id;
        }
    }
}
