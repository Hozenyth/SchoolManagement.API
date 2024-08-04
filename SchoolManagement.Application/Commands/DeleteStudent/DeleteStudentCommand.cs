using MediatR;

namespace SchoolManagement.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public int Registration { get; private set; }

        public DeleteStudentCommand(int registration)
        {
            Registration = registration;
        }
    }
}
