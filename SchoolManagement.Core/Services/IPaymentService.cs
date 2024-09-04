using SchoolManagement.Core.DTOs;

namespace SchoolManagement.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
