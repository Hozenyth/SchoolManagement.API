using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CourseRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public async Task<List<Course>> GetAllAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task AddAsync(Course course)
        {            
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Course> GetDetailsByIdAsync(int id)
        {
            var course = await _dbContext.Courses
                .Include(c => c.Teacher)
                .SingleOrDefaultAsync(c => c.Id == id);

            return course ?? throw new ArgumentException("Não encontrado"); 
        }
    }
}
