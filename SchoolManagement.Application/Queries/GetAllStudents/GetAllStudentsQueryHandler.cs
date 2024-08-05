using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolManagement.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentViewModel>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAllAsync();
            var studentViewModel = students.Select(p => new StudentViewModel(p.Id, p.Name, p.Registration, p.Email)).ToList();

            return studentViewModel;
        }
    }
}
