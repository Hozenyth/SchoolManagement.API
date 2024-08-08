using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student> GetDetailsByRegistrationAsync(int registration);       
        Task AddAsync(Student student);
        Task UpdateAsync();
        Task DeleteAsync();
    }
}
