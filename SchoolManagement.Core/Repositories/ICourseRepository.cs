using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task AddAsync(Course course);
    }
}
