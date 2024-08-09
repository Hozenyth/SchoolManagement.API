using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Unit>
    {
        private readonly ITeacherRepository _teacherRepository;
       
        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository, IConfiguration _configuration)
        {
            _teacherRepository = teacherRepository;
            
        }
        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetDetailsByRegistrationAsync(request.Registration);          
            teacher.Cancel();
            await _teacherRepository.DeleteAssync();

            return Unit.Value;
        }
    }
}
