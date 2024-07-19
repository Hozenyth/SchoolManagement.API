using FluentValidation;
using SchoolManagement.Application.InputModels;

namespace SchoolManagement.API.Validators
{
    public class CreateStudentValidator : AbstractValidator<NewStudentInputModel>
    {
        public CreateStudentValidator() 
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("the Name is required")
                .MaximumLength(100).WithMessage("The name student must have maximum of 100 characters");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("the Email is required")
                .MaximumLength(100).WithMessage("The Title must have maximum of 100 characters");

            RuleFor(c => c.Registration)
                .NotEmpty().WithMessage("the Registration is required");
        }
    }
}
