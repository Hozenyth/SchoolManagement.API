using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;

        public DeleteStudentCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(s => s.Registration == request.Registration);

            if (student != null)
                student.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
