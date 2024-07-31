using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetAllCourses
{
    public class GetAllCoursesQuery : IRequest<List<CourseViewModel>>
    {
        public string Query { get; set; }
        public GetAllCoursesQuery( string query) 
        {
            Query = query;
        }

    }
}
