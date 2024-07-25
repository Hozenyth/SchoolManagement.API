using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly SchoolManagementDbContext _dbContext;
        private readonly string _connectionString;
        public TeacherService(SchoolManagementDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("SchoolManagementCs");
        }
        public int CreateNewTeacher(NewTeacherInputModel inputModel)
        {
            var newRegistration = GenerateTeacherRegistration(inputModel.Registration);
            var teacher = new Teacher(inputModel.Name, inputModel.Email, newRegistration, inputModel.PhoneNumber);
            inputModel.Registration = newRegistration;
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();

            return teacher.Registration;
        }

        public void DeleteTeacher(int registration)
        {
            var teacher = _dbContext.Teachers.SingleOrDefault(p => p.Registration == registration);
            if (teacher != null)
            {
                teacher.Cancel();
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    var script = "UPDATE Teachers SET Status = @status WHERE registration = @registration";

                    sqlConnection.Execute(script, new { status = teacher.Status, registration});
                }
            }
                                     
        }

        public List<TeacherViewModel> GetAllTeachers()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Name, Email, PhoneNumber, Registration, CreatedAt FROM Teachers";

                return sqlConnection.Query<TeacherViewModel>(script).ToList();

            }           
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

            _dbContext.SaveChanges();
        }

        public int GenerateTeacherRegistration(int registration)
        {
            var currentDay = (DateTime.Now.Day).ToString();
            var currentYear = (DateTime.Now.Year).ToString();
            var currentMonth = (DateTime.Now.Month).ToString();

            var currentRegistration = int.Parse( currentYear + currentMonth + currentDay + registration);
           
            return currentRegistration;
        }
    }
}
