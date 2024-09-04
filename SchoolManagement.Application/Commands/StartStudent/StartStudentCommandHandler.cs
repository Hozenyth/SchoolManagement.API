using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Commands.StartCourse
{
    public class StartStudentCommandHandler : IRequestHandler<StartStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public StartStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;           
        }
        public async Task<Unit> Handle(StartStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);
            if (student == null)
            {
                BadRequestResult result = new BadRequestResult();
            }

            student.StartCourse();

            await _studentRepository.StartAsync(student);
            return Unit.Value;
        }
    }
}
