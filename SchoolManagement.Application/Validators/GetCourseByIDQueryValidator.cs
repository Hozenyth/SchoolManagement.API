using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Queries.GetCourseById;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class GetCourseByIDQueryValidator : AbstractValidator<GetCourseByIdQuery>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public GetCourseByIDQueryValidator(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(CourseExists).WithMessage("The course with the specified Id does not exist.");

        }
        private async Task<bool> CourseExists(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Courses.AnyAsync(c => c.Id == id, cancellationToken);
        }
    }
}
