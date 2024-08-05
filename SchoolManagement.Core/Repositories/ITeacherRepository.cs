using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<TeacherDTO>> GetAllAync();
       
        
    }
}
