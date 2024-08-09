using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Unit>
    {
        private readonly ITeacherRepository _teacherRepository;
        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetDetailsByRegistrationAsync(request.Registration);
            if (teacher != null)
                teacher.Update(request.Name, request.Email, request.PhoneNumber);
            await _teacherRepository.UpdateChangesAssync();
            return Unit.Value;
        }
    }
}
