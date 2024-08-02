using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly SchoolManagementDbContext _dbContext;

        public UpdateStudentCommandHandler(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students.SingleOrDefaultAsync(p => p.Registration == request.Registration);

            if (student != null)
                student.Update(request.Name, request.Email, request.PhoneNumber);            

           await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
