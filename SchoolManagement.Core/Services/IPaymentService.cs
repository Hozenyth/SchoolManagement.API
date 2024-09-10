using SchoolManagement.Core.DTOs;

namespace SchoolManagement.Core.Services
{
    public interface IPaymentService
    {
       Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}
