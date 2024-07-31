using MediatR;

namespace SchoolManagement.Application.Comands.CreateCourse
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
