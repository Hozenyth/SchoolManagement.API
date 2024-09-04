using MediatR;

namespace SchoolManagement.Application.Commands.StartCourse
{
    public class StartStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public StartStudentCommand(int id)
        {
            Id = id;                         
        }
    }
}
