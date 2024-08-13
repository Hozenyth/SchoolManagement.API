using FluentValidation;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Validators
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        private readonly SchoolManagementDbContext _dbContext;
        public CreateStudentCommandValidator(SchoolManagementDbContext dbContext)
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
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            var currentRegistration = int.Parse(currentYear.ToString() + currentMonth.ToString() + registration);         
            registration = currentRegistration;
            return _dbContext.Students.Where(r => r.Registration == registration).FirstOrDefault() == null ? true : false;
        }
    }
}
