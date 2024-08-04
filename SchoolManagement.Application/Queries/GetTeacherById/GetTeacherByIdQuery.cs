using MediatR;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery : IRequest<TeacherDetailsViewModel>
    {
        public int Registration { get; set; }
        public GetTeacherByIdQuery(int registration) 
        {
            Registration = registration;
        }

    }
}
