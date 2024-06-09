using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence;

namespace SchoolManagement.Application.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly SchoolManagementDbContext _dbContext;
        public TeacherService(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateNewTeacher(NewTeacherInputModel inputModel)
        {
            var teacher = new Teacher(inputModel.Name, inputModel.Email, inputModel.Registration, inputModel.PhoneNumber);
            _dbContext.Teachers.Add(teacher);
            return teacher.Id;
        }

        public void DeleteTeacher(int registration)
        {
            var teacher = _dbContext.Teachers.SingleOrDefault(p => p.Registration == registration);
            if (teacher != null)
                teacher.Cancel();

        }

        public List<TeacherViewModel> GetAllTeachers()
        {
            var teachers = _dbContext.Teachers;
            var teachersViewModel = teachers.Select(p => new TeacherViewModel(p.Id, p.Name, p.Email, p.PhoneNumber, p.Registration)).ToList();

            return teachersViewModel;
        }

        public TeacherDetailsViewModel GetTeacherDetails(int registration)
        {
            var teacher = _dbContext.Teachers.SingleOrDefault(p => p.Registration == registration);

            if (teacher != null)
            {
                var teacherDetailsViewModel = new TeacherDetailsViewModel(

                    teacher.Id,
                    teacher.Name,
                    teacher.PhoneNumber,
                    teacher.Registration
                );

                return teacherDetailsViewModel;
            }

            return null;

        }

        public void UpdateTeacher(UpdateTeacherInputModel inputModel, int registration)
        {
            var teacher = _dbContext.Teachers.SingleOrDefault(p => p.Registration == registration);
            if (teacher != null)
                teacher.Update(teacher.Name, teacher.Email, teacher.PhoneNumber);
        }
    }
}
