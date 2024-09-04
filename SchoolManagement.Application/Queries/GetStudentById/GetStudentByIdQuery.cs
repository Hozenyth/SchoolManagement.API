using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentDetailsViewModel>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
