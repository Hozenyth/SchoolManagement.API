using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public UpdateTeacherCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.SingleOrDefaultAsync(p => p.Registration == request.Registration);
            if (teacher != null)
                teacher.Update(request.Name, request.Email, request.PhoneNumber);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
