using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Commands.UpdateTeacher;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommand>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public UpdateTeacherCommandValidator(SchoolManagementDbContext dbContex)
        {
            _dbContext = dbContex;  

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

            RuleFor(e => e.Registration)
                .NotEmpty()
                .WithMessage("Registration is required");

            RuleFor(e => e.Registration).Must(IsRegistrationExist).WithMessage("Registration not found");
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
