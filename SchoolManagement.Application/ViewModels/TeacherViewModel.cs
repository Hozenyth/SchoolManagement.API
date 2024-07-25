namespace SchoolManagement.Application.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Registration { get; private set; }
        public string CreatedAt { get; private set; }

        public TeacherViewModel(int id, string name, string email,string phoneNumber, int registration, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Registration = registration;
            CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
        
        }
    }
}
