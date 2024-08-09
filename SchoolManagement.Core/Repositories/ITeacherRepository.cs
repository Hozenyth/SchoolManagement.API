using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<TeacherDTO>> GetAllAync();      
        Task<Teacher> GetDetailsByRegistrationAsync(int registration);
        Task AddAssync(Teacher teacher);
        Task UpdateChangesAssync();
        Task DeleteAssync();

    }
}
