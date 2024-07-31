using MediatR;

namespace SchoolManagement.Application.Comands.UpdateCourse
{
    public class UpdateCourseComand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
