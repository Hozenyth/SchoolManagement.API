using MediatR;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;

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
            var student = await _studentRepository.GetByIdAsync(request.Id);
                
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
