using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Services.Interfaces
{
    public interface ICourseService
    {
        List<CourseViewModel> GetAll(string query);
        CourseDetailsViewModel GetCourse(int id);

        int CreateCourse(NewCourseInputModel inputModel);

        void UpdateCourse(UpdateCourseInputModel inputModel);
        void DeleteCourse(int id);
    }
}
