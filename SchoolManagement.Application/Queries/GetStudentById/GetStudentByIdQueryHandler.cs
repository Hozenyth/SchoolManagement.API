using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDetailsViewModel>
    {
        private readonly IStudentRepository _studentRepository;       
        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;           
        }
        public async Task<StudentDetailsViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetDetailsByRegistrationAsync(request.Registration);
                
            if (student == null) return null;

            var studentDetailViewModel = new StudentDetailsViewModel(
                student.Id,
                student.Name,
                student.Registration,
                student.PhoneNumber,
                student.Email,
                student.CreatedAt);

            return studentDetailViewModel;
        }
    }
}
