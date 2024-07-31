using MediatR;

namespace SchoolManagement.Application.Comands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
      
        public int Id { get; private set; }

        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
