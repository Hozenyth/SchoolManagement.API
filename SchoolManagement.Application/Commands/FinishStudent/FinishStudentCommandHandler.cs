﻿using MediatR;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application.Commands.FinishStudent
{
    public class FinishStudentCommandHandler : IRequestHandler<FinishStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        public FinishStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Unit> Handle(FinishStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student != null)
            {
                student.FinishCourse();
                await _studentRepository.FinishAsync(student);
            }
           
            return Unit.Value;
        }
    }
}
