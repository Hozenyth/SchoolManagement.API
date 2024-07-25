using MediatR;

namespace SchoolManagement.Application.Comands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Registration { get; set; }
    }
}
