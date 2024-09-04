using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Queries.GetStudentById;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class GetStudentByIdQueryValidator : AbstractValidator<GetStudentByIdQuery>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetStudentByIdQueryValidator(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(CourseExists).WithMessage("The Student with the specified Id does not exist.");

        }
        private async Task<bool> CourseExists(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Courses.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
