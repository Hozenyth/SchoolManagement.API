using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDetailsViewModel>
    {
        public int Registration { get; set; }

        public GetStudentByIdQuery(int registration)
        {
            Registration = registration;
        }
    }
}
