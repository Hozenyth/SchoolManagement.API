using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CourseService(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public int CreateCourse(NewCourseInputModel inputModel)
        {
            var createCourse = new Course(inputModel.Title, inputModel.Description);

            _dbContext.Courses.Add(createCourse);
            _dbContext.SaveChanges();

            return createCourse.Id;
        }

        public void DeleteCourse(int id)
        {
            var course = _dbContext.Courses.SingleOrDefault(c => c.Id == id);

            if(course != null) 
               course.Cancel();
           
            _dbContext.SaveChanges();
        }

        public List<CourseViewModel> GetAll(string query)
        {
            var course = _dbContext.Courses;

            var couserViewModel = course.Select( c => new CourseViewModel(c.Id, c.Title, c.Description, c.CreatedAt, c.StartedAt, c.FinishedAt)).ToList();

            return couserViewModel;          
        }

        public CourseDetailsViewModel GetCourse(int id)
        {
            var course = _dbContext.Courses
                .Include(c => c.Teacher)
                .SingleOrDefault(c => c.Id == id);

            if (course != null)
            {
                var courseDetailsViewModel = new CourseDetailsViewModel(
                    course.Id,
                    course.Title,
                    course.Description,
                    course.CreatedAt,
                    course.StartedAt,
                    course.FinishedAt,
                    course.Teacher.Name
                    );

                return courseDetailsViewModel;
            }
            return null;
        }

        public void UpdateCourse(UpdateCourseInputModel inputModel)
        {
            var course = _dbContext.Courses.SingleOrDefault(c => c.Id == inputModel.Id);
            if(course != null)
               course.Update(inputModel.Title, inputModel.Description);
            
            _dbContext.SaveChanges();
        }

        public void UpdateTeacherCourse(UpdateTeacherCourseInputModel inputModel)
        {
           
            var course = _dbContext.Courses.SingleOrDefault(c => c.Id == inputModel.Id);
            if (course != null)
            {
                course.UpdateTeacherCourse(inputModel.TeacherId);
                _dbContext.SaveChanges();
            }
        }
    }
}
