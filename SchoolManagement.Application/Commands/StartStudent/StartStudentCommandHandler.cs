using MediatR;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Core.Services;

namespace SchoolManagement.Application.Commands.StartCourse
{
    public class StartStudentCommandHandler : IRequestHandler<StartStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPaymentService _paymentService;

        public StartStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;           
        }
      
       async Task<bool> IRequestHandler<StartStudentCommand, bool>.Handle(StartStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);           

            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, student.Payment);

            _paymentService.ProcessPayment(paymentInfoDto);
          
            student.StartCourse();

            await _studentRepository.StartAsync(student);
            //await _projectRepository.SaveChangesAsync();

            return true;
        }
    }
}
