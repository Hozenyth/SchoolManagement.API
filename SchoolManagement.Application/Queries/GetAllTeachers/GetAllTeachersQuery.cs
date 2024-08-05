using MediatR;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.DTOs;

namespace SchoolManagement.Application.Queries.GetAllTeachers
{
    public class GetAllTeachersQuery : IRequest<List<TeacherDTO>>
    {
        public string Query { get; set; }

        public GetAllTeachersQuery(string query)
        {
            Query = query;
        }
    }
}
