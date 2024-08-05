using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
    }
}
