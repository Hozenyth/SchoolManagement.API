using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;
        private readonly string _connectionString;

        public DeleteTeacherCommandHandler(SchoolManagementDbContext dbContext, IConfiguration _configuration)
        {
            _dbContext = dbContext;
            _connectionString = _configuration.GetConnectionString("SchoolManagementCs");
        }
        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.SingleOrDefaultAsync(p => p.Registration == request.Registration);
           
            teacher.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
