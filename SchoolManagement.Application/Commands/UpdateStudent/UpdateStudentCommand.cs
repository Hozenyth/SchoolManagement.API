using MediatR;
using SchoolManagement.Application.InputModels;

namespace SchoolManagement.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Registration { get; set; }
    }
}
