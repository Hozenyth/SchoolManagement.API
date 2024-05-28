namespace SchoolManagement.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Registration { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }
        public List<Course> Courses { get; private set; }

        
        public Teacher( string name, string email, int registration, string phoneNumber)
        {
            Name = name;
            Email = email;
            Registration = registration;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.Now;
            IsActive = true;
            
            Courses = new List<Course>();
                
        }
    }
}
