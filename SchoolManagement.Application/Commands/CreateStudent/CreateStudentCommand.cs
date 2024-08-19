using MediatR;

namespace SchoolManagement.Application.Comands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Registration { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }      
    }  
}
