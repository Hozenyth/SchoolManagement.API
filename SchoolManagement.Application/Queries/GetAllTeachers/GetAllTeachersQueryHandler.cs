using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.ViewModels;

namespace SchoolManagement.Application.Queries.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherViewModel>>
    {
        private readonly string _connectionString;
        public GetAllTeachersQueryHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SchoolManagementCs");
        }
        public async Task<List<TeacherViewModel>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Name, Email, PhoneNumber, Registration, CreatedAt FROM Teachers";
                var teachers = await sqlConnection.QueryAsync<TeacherViewModel>(script);

                return teachers.ToList();
            }
        }
    }
}
