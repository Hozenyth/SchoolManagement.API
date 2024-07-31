using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
    {
        public string Query { get; set; }

        public GetAllStudentsQuery(string query)
        {
            Query = query;            
        }
    }
}
