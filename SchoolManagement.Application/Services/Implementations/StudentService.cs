using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly SchoolManagementDbContext _dbContext;

        public StudentService(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateStudent(NewStudentInputModel inputModel)
        {          
            var newRegistration = GenerateStudentRegistration(inputModel.Registration);
            var student = new Student(inputModel.Name, inputModel.PhoneNumber, newRegistration, inputModel.Email);          
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return student.Registration;
        }

        public void DeleteStudent(int registration)
        {
            var student = _dbContext.Students.SingleOrDefault(s => s.Registration == registration);

            if (student != null)
                student.Cancel();

            _dbContext.SaveChanges();

        }
      
        public List<StudentViewModel> GetAll(string query)
        {
            var students = _dbContext.Students;

            var studentViewModel = students.Select(p => new StudentViewModel(p.Id, p.Name, p.Registration, p.Email)).ToList();

            return studentViewModel;
        }

        public StudentDetailsViewModel GetByRegistration(int registration)
        {
            var student = _dbContext.Students.SingleOrDefault(p => p.Registration == registration);
            if (student != null)
            {
                var studentDetailViewModel = new StudentDetailsViewModel(
              student.Id,
              student.Name,
              student.Registration,
              student.PhoneNumber,
              student.Email,
              student.CreatedAt);

                return studentDetailViewModel;
            }
            else
                return null;

        }

        public void UpdateStudent(UpdateStudentInputModel inputModel, int registration)
        {
            var student = _dbContext.Students.SingleOrDefault(p => p.Registration == registration);

            if (student != null)
                student.Update(inputModel.Name, inputModel.Email, inputModel.PhoneNumber);
            
            _dbContext.SaveChanges();
        }
    
        public int GenerateStudentRegistration(int registration)
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            var currentRegistration = int.Parse(currentYear.ToString() + currentMonth.ToString() + registration.ToString());

            return currentRegistration;

        }
    }
}
