using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolManagementDbContext _dbContext;
        private readonly string _connectionString;

        public TeacherRepository(SchoolManagementDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("SchoolManagementCs");
        }
      
        public async Task<List<TeacherDTO>> GetAllAync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Name, Email, PhoneNumber, Registration, CreatedAt FROM Teachers";
                var teachers = await sqlConnection.QueryAsync<TeacherDTO>(script);

                return teachers.ToList();
            }
        }
       
        public async Task<Teacher> GetDetailsByRegistrationAsync(int registration)
        {
            var teacher = await _dbContext.Teachers.SingleOrDefaultAsync(p => p.Registration == registration);
 
            return teacher ?? throw new ArgumentException("Not Found");

        }
                    
    }
}
