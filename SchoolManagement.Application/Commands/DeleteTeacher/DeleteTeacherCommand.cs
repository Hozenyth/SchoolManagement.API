using MediatR;

namespace SchoolManagement.Application.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest<Unit>
    {
        public int Registration { get; set; }
        public DeleteTeacherCommand(int registration) 
        { 
            Registration = registration;
        }
    }
}
