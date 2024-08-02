using MediatR;

namespace SchoolManagement.Application.Comands.UpdateTeacherCourse
{
    public class UpdateTeacherCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
      
    }
}
