using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetDetailsByRegistrationAsync(request.Registration);

            if (student != null)
                student.Update(request.Name, request.Email, request.PhoneNumber);            

           await _studentRepository.UpdateAsync();

            return Unit.Value;
        }
    }
}
