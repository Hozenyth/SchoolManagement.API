using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetAllTeachers
{
    public class GetAllTeachersQuery : IRequest<List<TeacherViewModel>>
    {
        public string Query { get; set; }

        public GetAllTeachersQuery(string query)
        {
            Query = query;
        }
    }
}
