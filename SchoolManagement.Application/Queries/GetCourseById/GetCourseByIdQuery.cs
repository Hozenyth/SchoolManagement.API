using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<CourseDetailsViewModel>
    {
        public int Id { get; set; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;            
        }
    }
}
