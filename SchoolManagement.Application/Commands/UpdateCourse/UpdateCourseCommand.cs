using MediatR;

namespace SchoolManagement.Application.Comands.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
    }
}
