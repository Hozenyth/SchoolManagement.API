using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentViewModel> GetAll(string query);

        StudentDetailsViewModel GetByRegistration(int registration);

        int CreateStudent(NewStudentInputModel inputModel);

        void UpdateStudent(UpdateStudentInputModel inputModel, int registration);

        void DeleteStudent(int registration);
        
    }
}
