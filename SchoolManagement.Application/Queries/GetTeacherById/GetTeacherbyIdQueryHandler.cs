using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.ViewModels;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.Application.Queries.GetTeacherById
{
    public class GetTeacherbyIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDetailsViewModel>
    {
        private readonly ITeacherRepository _teacherRepository;
        public GetTeacherbyIdQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<TeacherDetailsViewModel> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.GetDetailsByRegistrationAsync(request.Registration);

            if (teacher == null) return null;

            var teacherDetailsViewModel = new TeacherDetailsViewModel(

                teacher.Name,
                teacher.PhoneNumber,
                teacher.Registration
            );

            return teacherDetailsViewModel;
        }
    }
}
