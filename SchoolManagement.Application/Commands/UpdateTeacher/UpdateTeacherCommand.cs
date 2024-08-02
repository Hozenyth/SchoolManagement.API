using MediatR;

namespace SchoolManagement.Application.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get;set; }
        public int Registration { get; set; }
    }
}
