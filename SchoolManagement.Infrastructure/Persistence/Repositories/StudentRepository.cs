using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolManagementDbContext _dbContext;
        public StudentRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetAllAsync()
        {
           return await _dbContext.Students.ToListAsync();
        }
    }
}
