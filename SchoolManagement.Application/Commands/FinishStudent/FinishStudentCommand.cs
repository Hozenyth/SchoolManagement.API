using MediatR;

namespace SchoolManagement.Application.Commands.FinishStudent
{
    public class FinishStudentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public FinishStudentCommand(int id)
        {
            Id = id;
        }
    }
}
