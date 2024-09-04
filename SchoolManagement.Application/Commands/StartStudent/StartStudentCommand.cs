using MediatR;

namespace SchoolManagement.Application.Commands.StartCourse
{
    public class StartStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public StartStudentCommand(int id)
        {
            Id = id;
            
        }
    }
}
