using FluentValidation;
using SchoolManagement.Application.Comands.UpdateCourse;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
       
        public UpdateCourseCommandValidator() 
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Description is required");               
        }
    }
}
