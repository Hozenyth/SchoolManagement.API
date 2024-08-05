using MediatR;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.Application.Queries.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherDTO>>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository)
        {
           _teacherRepository = teacherRepository;
        }

        public async Task<List<TeacherDTO>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _teacherRepository.GetAllAync();
        }

        
    }
}
