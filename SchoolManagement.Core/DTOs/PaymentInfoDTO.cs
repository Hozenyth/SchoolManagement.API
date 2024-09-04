namespace SchoolManagement.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int idStudent, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            IdStudent= idStudent;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }

        public int IdStudent { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string Cvv { get; private set; }
        public string ExpiresAt { get; private set; }
        public string FullName { get; private set; }
        public decimal Amount { get; private set; }
    }
}
