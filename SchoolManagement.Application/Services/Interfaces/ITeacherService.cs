using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherViewModel> GetAllTeachers();

        TeacherDetailsViewModel GetTeacherDetails( int registration);

        int CreateNewTeacher(NewTeacherInputModel inputmodel);

        void UpdateTeacher( UpdateTeacherInputModel inputModel, int registration);

        void DeleteTeacher( int registration);

    }
}
