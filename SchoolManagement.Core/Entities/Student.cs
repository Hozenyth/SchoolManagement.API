using SchoolManagement.Core.Enums;

namespace SchoolManagement.Core.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Registration { get; private set; }       
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public decimal Payment { get; private set; }
        public DateTime CreatedAt { get; private set; }              
        public StudentStatusEnum StudentStatus { get; private set; }
        public List<Course_Student> Course_Students { get; private set; }

        public Student( string name, string phoneNumber, int registration, string email, string role, string password) 
        {
            Name = name;
            PhoneNumber = phoneNumber;            
            Registration = registration;
            Email = email;           
            CreatedAt = DateTime.Now;
            IsActive = true;
            StudentStatus = StudentStatusEnum.Created;
            Role = role;
            Password = password;
        }

        public void Cancel()
        {
            if (IsActive && StudentStatus == StudentStatusEnum.Created)
            {
                IsActive = false;
                StudentStatus = StudentStatusEnum.Cancelled;
            }
        }
        public void StartCourse()
        {
            if (IsActive && StudentStatus == StudentStatusEnum.Created)
            {               
                StudentStatus = StudentStatusEnum.InProgress;
            }
        }

        public void SetPaymentPending()
        {
            StudentStatus = StudentStatusEnum.PaymentPending;
        }
        public void FinishCourse()
        {
            if (IsActive && StudentStatus == StudentStatusEnum.InProgress)
            {             
                StudentStatus = StudentStatusEnum.Finished;
            }
        }

        public void Update(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;           
        }
        
    }
}
