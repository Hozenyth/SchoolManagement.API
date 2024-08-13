using FluentValidation;
using MediatR;
using SchoolManagement.Application.Comands.CreateTeacher;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {

        private readonly SchoolManagementDbContext _dbContext;
        public CreateTeacherCommandValidator(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage(" Email is not valid");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone Number is required");

            RuleFor(e => e.Registration).Must(IsRegistrationExist).WithMessage("Registration Already Exist.");

        }

        private bool IsRegistrationExist(int registration)
        {
            var currentDay = (DateTime.Now.Day).ToString();
            var currentYear = (DateTime.Now.Year).ToString();
            var currentMonth = (DateTime.Now.Month).ToString();

            var currentRegistration = int.Parse(currentYear + currentMonth + currentDay + registration);          
            registration = currentRegistration;
            return _dbContext.Teachers.Where(r => r.Registration == registration).FirstOrDefault() == null ? true : false;
        }
    }
}
