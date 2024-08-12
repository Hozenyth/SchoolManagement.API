using FluentValidation;
using SchoolManagement.Application.Comands.CreateCourse;

namespace SchoolManagement.Application.Validators
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator() 
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
